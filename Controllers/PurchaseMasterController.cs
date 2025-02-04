using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseMasterController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PurchaseMasterController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddPurchaseMaster(PurchaseMaster purchaseMaster)
        {
            try
            {
                if (await _dbContext.PurchaseMasters.AnyAsync(o => o.SupplierId == purchaseMaster.SupplierId))
                {
                    if (!await _dbContext.PurchaseMasters.AnyAsync(o => o.SupplierId == purchaseMaster.SupplierId && o.TransactionYearId == purchaseMaster.TransactionYearId && o.BillNo == o.BillNo))
                    {
                        _dbContext.PurchaseMasters.Add(purchaseMaster);
                        await _dbContext.SaveChangesAsync();
                        return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                    }
                    else
                    {
                        return Ok(new { Status = "Fail", Result = "Bill No is already Exists with same Supplier and Transaction Year" });
                    }
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Supplier not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpPut]
        [Route("EditPurchaseMaster")]
        public async Task<IActionResult> EditPurchaseMaster(PurchaseMaster purchaseMaster)
        {
            try
            {
                if (_dbContext.PurchaseMasters.Any(o => o.PurchaseId == purchaseMaster.PurchaseId))
                {
                    _dbContext.PurchaseMasters.Update(purchaseMaster);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Already Exists" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("AllPurchaseMaster")]
        public async Task<IActionResult> getPurchaseMaster()
        {
            try
            {
                var Data = await _dbContext.PurchaseMasters.ToArrayAsync();
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
                var Data = await _dbContext.PurchaseMasters.Where(o => o.PurchaseId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deletePurchaseMaster(int? Id)
        {
            try
            {
                var Data = await _dbContext.PurchaseMasters.Where(o => o.PurchaseId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.PurchaseMasters.Remove(Data);
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
