using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutwordItemController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public OutwordItemController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddOutword(OutwordItem outwordItem)
        {
            try
            {
                if (!_dbContext.OutwordItems.Any(o => o.OutwordStockId == outwordItem.OutwordStockId))
                {
                    _dbContext.OutwordItems.Add(outwordItem);
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
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditOutwordItem(OutwordItem outwordItem)
        {
            try
            {
                if (!_dbContext.OutwordItems.Any(o => o.OutwordStockId != outwordItem.OutwordStockId))
                {
                    _dbContext.OutwordItems.Update(outwordItem);
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
        [Route("List")]
        public async Task<IActionResult> getOutwordItem()
        {
            try
            {
                var Data = await (from A in _dbContext.OutwordItems
                                  join B in _dbContext.Materials on A.MaterialId equals B.MaterialId
                                  join C in _dbContext.OutwardMasters on A.OutwordId equals C.OutwordId
                                  select new
                                  {
                                      B.MaterialId,
                                      B.MaterialName,
                                      B.Category,
                                      B.Description,
                                      B.Price,
                                      B.Qty,
                                      C.ContactNo,
                                      C.StaffMaster,
                                      C.Reason,
                                      C.Givento,
                                      C.OutwordDate,
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
                var Data = await _dbContext.OutwordItems.Where(o => o.OutwordStockId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteOutwordStock(int? Id)
        {
            try
            {
                var Data = await _dbContext.OutwordItems.Where(o => o.OutwordStockId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.OutwordItems.Remove(Data);
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
