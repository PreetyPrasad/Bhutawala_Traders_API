using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplyCreditController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplyCreditController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertApplyCredit")]
        public async Task<IActionResult> AddApplyCredit(ApplyCredit applyCredit)
        {
            try
            {
                if (!_dbContext.ApplyCredits.Any())
                {
                    _dbContext.ApplyCredits.Add(applyCredit);
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
    }
}
