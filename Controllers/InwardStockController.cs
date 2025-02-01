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
        [Route("InsertInwardStock")]
        public async Task<IActionResult> AddInwardStock(InwordStock InwordStock)
        {
            try
            {
                var purchaseExists = await _dbContext.PurchaseMasters.AnyAsync(o => o.PurchaseId == InwordStock.PurchaseId);
                var materialExists = await _dbContext.Materials.AnyAsync(o => o.MaterialId == InwordStock.MaterialId);
                List<string> Error = new List<string>();

                if (!purchaseExists) {
                    Error.Add("Purchase Entry not exists");
                }

                if (!materialExists)
                {
                    Error.Add("Material Entry not exists");
                }

                if (Error.Count == 0)
                {
                    _dbContext.Inwordstocks.Add(InwordStock);
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

        [HttpPut]
        [Route("EditInwordStock")]
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
        [Route("AllInwordStock")]
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
