using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PurchaseReturnController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            try
            {
                if (purchaseReturn == null || purchaseReturn.Qty <= 0)
                {
                    return BadRequest(new { Status = "Fail", Result = "Invalid Qty value" });
                }
                var purchaseMaster = await _dbContext.PurchaseMasters
                    .FirstOrDefaultAsync(pm => pm.PurchaseId == purchaseReturn.PurchaseId);

                if (purchaseMaster == null)
                {
                    return BadRequest(new { Status = "Fail", Result = "Invalid PurchaseId" });
                }

                var newPurchaseReturn = new PurchaseReturn
                {
                    Qty = purchaseReturn.Qty,
                    Unit = string.Empty,
                    PurchaseId = purchaseReturn.PurchaseId,
                    InvoiceId = null,
                    ReturnDate = DateTime.UtcNow,
                    LogDate = DateTime.UtcNow
                };

                _dbContext.PurchaseReturns.Add(newPurchaseReturn);
                await _dbContext.SaveChangesAsync();

                var inwordStocks = await _dbContext.Inwordstocks
                    .Where(i => i.PurchaseId == newPurchaseReturn.PurchaseId)
                    .ToListAsync();

                foreach (var stock in inwordStocks)
                {
                    if (stock.Qty >= purchaseReturn.Qty)
                    {
                        stock.Qty -= purchaseReturn.Qty;
                        _dbContext.Inwordstocks.Update(stock);
                    }
                    else
                    {
                        stock.Qty = 0;
                        _dbContext.Inwordstocks.Update(stock);
                    }
                }

                await _dbContext.SaveChangesAsync();

                return Ok(new { Status = "Ok", Result = "Successfully Saved", Qty = newPurchaseReturn.Qty });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> getPurchaseReturn()
        {
            try
            {
                var Data = await (from A in _dbContext.PurchaseReturns
                                  join B in _dbContext.PurchaseMasters on A.PurchaseId equals B.PurchaseId
                                  join S in _dbContext.Suppliers on B.SupplierId equals S.SupplierId
                                  select new
                                  {
                                      B.PurchaseId,
                                      B.GST_Type,
                                      B.Total,
                                      B.BillNo,
                                      B.PurchaseDate,
                                      B.GST,
                                      B.GrossTotal,
                                      B.NoticePeriod,
                                      Supplier = S.BusinessName,
                                  }).ToListAsync();


                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }


        [HttpGet]
        [Route("purchaseDetail/{BillNo}/{InvoiceDate}")]
        public async Task<IActionResult> getPurchaseReturn(string BillNo, DateTime InvoiceDate)
        {
            try
            {
                var Data = await (from B in _dbContext.PurchaseMasters
                                  join S in _dbContext.Suppliers on B.SupplierId equals S.SupplierId
                                  select new
                                  {
                                      B.PurchaseId,
                                      B.GST_Type,
                                      B.Total,
                                      B.BillNo,
                                      B.PurchaseDate,
                                      B.GST,
                                      B.GrossTotal,
                                      B.NoticePeriod,
                                      Supplier = S.BusinessName,
                                      stocks = (from I in _dbContext.Inwordstocks
                                                join M in _dbContext.Materials on I.MaterialId equals M.MaterialId
                                                where I.PurchaseId == B.PurchaseId
                                                select new
                                                {
                                                    I.StockId,
                                                    I.Qty,
                                                    I.Cost,
                                                    I.MaterialId,
                                                    M.MaterialName,
                                                    M.Price,
                                                    M.Brand,
                                                    M.Unit,
                                                }).ToList()
                                  }).Where(o => o.BillNo == BillNo && o.PurchaseDate == InvoiceDate).ToListAsync();


                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<IActionResult> getDetails(int? Id)
        {
            try
            {
                var Data = await _dbContext.PurchaseReturns.Where(o => o.PurchaseReturnId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    return Ok(new { Status = "OK", Result = Data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }



        [HttpGet]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> deletePurchaseReturn(int? Id)
        {
            try
            {
                var Data = await _dbContext.PurchaseReturns.Where(o => o.PurchaseReturnId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.PurchaseReturns.Remove(Data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Deleted Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }
    }
}
