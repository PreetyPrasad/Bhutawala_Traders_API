using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InwardStockController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public InwardStockController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddInwardStock(InwordStock InwordStock)
        {
            try
            {
                var purchaseExists = await _dbContext.PurchaseMasters.AnyAsync(o => o.PurchaseId == InwordStock.PurchaseId);
                var materialExists = await _dbContext.Materials.AnyAsync(o => o.MaterialId == InwordStock.MaterialId);
                List<string> Error = new List<string>();

                if (!purchaseExists)
                {
                    Error.Add("Purchase Entry does not exist");
                }

                if (!materialExists)
                {
                    Error.Add("Material Entry does not exist");
                }

                if (Error.Count == 0)
                {
                    var existingStock = await _dbContext.Inwordstocks
                        .FirstOrDefaultAsync(o => o.PurchaseId == InwordStock.PurchaseId && o.MaterialId == InwordStock.MaterialId);

                    var sumInward = await _dbContext.Inwordstocks
                        .Where(o => o.PurchaseId == InwordStock.PurchaseId)
                        .SumAsync(o => (o != null ? (o.Qty * o.Cost) : 0));

                    var totalPurchaseAmount = await _dbContext.PurchaseMasters
                        .Where(o => o.PurchaseId == InwordStock.PurchaseId)
                        .Select(o => o.Total)
                        .FirstOrDefaultAsync();

                    var newStockAmount = (existingStock != null ? (existingStock.Qty + InwordStock.Qty) * InwordStock.Cost : InwordStock.Qty * InwordStock.Cost);

                    if (sumInward + newStockAmount > totalPurchaseAmount)
                    {
                        return Ok(new { Status = "Fail", Result = "Inward Stock Amount is greater than Purchase Amount" });
                    }

                    if (existingStock != null)
                    {
                        // Update existing stock
                        existingStock.Qty += InwordStock.Qty;
                        existingStock.Cost = InwordStock.Cost; // Update cost if needed
                        existingStock.RecivedDate = InwordStock.RecivedDate;
                        existingStock.Note = InwordStock.Note;

                        _dbContext.Inwordstocks.Update(existingStock);
                    }
                    else
                    {
                        // Add new stock entry
                        _dbContext.Inwordstocks.Add(InwordStock);
                    }

                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = Error });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }



        [HttpGet]
        [Route("InwordStocks/{PurchaseId}")]
        public async Task<IActionResult> getInwordStock(int PurchaseId)
        {
            try
            {
                var Data = await (from A in _dbContext.Inwordstocks
                                  join B in _dbContext.Materials on A.MaterialId equals B.MaterialId
                                  join C in _dbContext.PurchaseMasters on A.PurchaseId equals C.PurchaseId
                                  join E in _dbContext.StaffMasters on A.StaffId equals E.StaffId
                                  where A.PurchaseId == PurchaseId
                                  select new
                                  {
                                      A.StockId,
                                      B.MaterialName,
                                      C.BillNo,
                                      C.PurchaseDate,
                                      B.Qty,
                                      A.Cost,
                                      A.RecivedDate,
                                      A.Note,
                                        B.Unit,
                                        Iwarded = A.Qty,
                                      Staffname = E.FullName
                                  }).ToListAsync();

                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditInwordStock(InwordStock InwordStock)
        {
            try
            {
                var purchaseExists = await _dbContext.PurchaseMasters.AnyAsync(o => o.PurchaseId == InwordStock.PurchaseId);
                var materialExists = await _dbContext.Materials.AnyAsync(o => o.MaterialId == InwordStock.MaterialId);
                List<string> Error = new List<string>();

                if (!purchaseExists)
                {
                    Error.Add("Purchase Entry not exists");
                }

                if (!materialExists)
                {
                    Error.Add("Material Entry not exists");
                }

                if (Error.Count == 0)
                {
                    _dbContext.Inwordstocks.Update(InwordStock);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = Error });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> getInwordStock()
        {
            try
            {
                var Data = await (from A in _dbContext.Inwordstocks
                                  join B in _dbContext.Materials on A.MaterialId equals B.MaterialId
                                  join C in _dbContext.PurchaseMasters on A.PurchaseId equals C.PurchaseId
                                  join D in _dbContext.Suppliers on A.StockId equals D.SupplierId
                                  join E in _dbContext.StaffMasters on A.StaffId equals E.StaffId
                                  select new
                                  {
                                      A.StockId,
                                      B.MaterialId,
                                      C.SupplierId,
                                      D.BusinessName,
                                      B.MaterialName,
                                      C.BillNo,
                                      C.PurchaseDate,
                                      A.Qty,
                                      A.Unit,
                                      A.Cost,
                                      A.RecivedDate,
                                      A.Note,
                                      Staffname=E.FullName
                                  }).ToListAsync();
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
                var Data = await _dbContext.Inwordstocks.Where(o => o.StockId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteInwordStock(int? Id)
        {
            try
            {
                var Data = await _dbContext.Inwordstocks.Where(o => o.StockId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.Inwordstocks.Remove(Data);
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
