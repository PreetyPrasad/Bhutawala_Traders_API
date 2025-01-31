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
                if (!_dbContext.Inwordstocks.Any(o => o.StockId == InwordStock.StockId))
                {
                    _dbContext.Inwordstocks.Add(InwordStock);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Already Exists" });
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
                if (!_dbContext.Inwordstocks.Any(o => o.StockId == InwordStock.StockId))
                {
                    _dbContext.Inwordstocks.Update(InwordStock);
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
        [Route("AllInwordStock")]
        public async Task<IActionResult> getInwordStock()
        {
            try
            {
                var Data = await _dbContext.Inwordstocks.ToArrayAsync();
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
