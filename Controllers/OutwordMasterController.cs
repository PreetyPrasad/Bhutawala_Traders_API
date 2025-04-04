using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutwordMasterController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public OutwordMasterController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddOutwordMaster(OutwordMaster outwordMaster)
        {
            try
            {

                if (!_dbContext.OutwardMasters.Any(o => o.OutwordId == outwordMaster.OutwordId))
                {
                    _dbContext.OutwardMasters.Add(outwordMaster);
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
        public async Task<IActionResult> EditOutwordItem(OutwordMaster outwordMaster)
        {
            try
            {
                if (_dbContext.OutwardMasters.Any(o => o.OutwordId != outwordMaster.OutwordId && o.Givento == outwordMaster.Givento))
                {
                    _dbContext.OutwardMasters.Update(outwordMaster);
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
        public async Task<IActionResult> getOutwordMaster()
        {
            try
            {
                var Data = await (from A in _dbContext.OutwardMasters
                                  join B in _dbContext.StaffMasters on A.StaffId equals B.StaffId
                                  select new
                                  {
                                      A.OutwordId,
                                      A.StaffId,
                                      A.Reason,
                                      A.Givento,
                                      A.ContactNo,
                                      A.OutwordDate
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
        public async Task<IActionResult> getOutwordMaster(int? Id)
        {
            try
            {
                var Data = await _dbContext.OutwardMasters.Where(o => o.OutwordId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteOutwordMaster(int? Id)
        {
            try
            {
                var Data = await _dbContext.OutwardMasters.Where(o => o.OutwordId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.OutwardMasters.Remove(Data);
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
