using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public SalesReturnController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
         public async Task<IActionResult> Add(SalesReturn salesReturn)
         {
             try
             {
                 if (!_dbContext.SalesReturns.Any(o => o.SalesReturnId == salesReturn.SalesReturnId))
                 {
                     _dbContext.SalesReturns.Add(salesReturn);
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
         [Route("Edit")]
         public async Task<IActionResult> EditSalesReturn(SalesReturn salesReturn)
         {
             try
             {
                 if (!_dbContext.SalesReturns.Any(o => o.SalesReturnId == salesReturn.SalesReturnId))
                 {
                     _dbContext.SalesReturns.Update(salesReturn);
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
         [Route("All")]
         public async Task<IActionResult> get()
         {
             try
             {
                 var Data = await _dbContext.SalesReturns.ToArrayAsync();
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
                 var Data = await _dbContext.SalesReturns.Where(o => o.SalesReturnId == Id).FirstOrDefaultAsync();

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
         public async Task<IActionResult> delete(int? Id)
         {
             try
             {
                 var Data = await _dbContext.SalesReturns.Where(o => o.SalesReturnId == Id).FirstOrDefaultAsync();

                 if (Data != null)
                 {
                     _dbContext.SalesReturns.Remove(Data);
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

