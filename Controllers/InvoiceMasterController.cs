using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceMasterController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public InvoiceMasterController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertInvoiceMaster")]
        public async Task<IActionResult> AddInvoiceMaster(InvoiceMaster invoiceMaster)
        {
            try
            {
                if (!_dbContext.InvoiceMasters.Any(o => o.InvoiceId == invoiceMaster.InvoiceId))
                {
                    _dbContext.InvoiceMasters.Add(invoiceMaster);
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
        [Route("EditInvoiceMaster")]
        public async Task<IActionResult> EditInvoiceMaster(InvoiceMaster invoiceMaster)
        {
            try
            {
                if (!_dbContext.InvoiceMasters.Any(o => o.InvoiceId == invoiceMaster.InvoiceId))
                {
                    _dbContext.InvoiceMasters.Update(invoiceMaster);
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
        [Route("AllInvoiceMaster")]
        public async Task<IActionResult> getInvoiceMaster()
        {
            try
            {
                var Data = await _dbContext.InvoiceMasters.ToArrayAsync();
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
                var Data = await _dbContext.InvoiceMasters.Where(o => o.InvoiceId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteInvoiceMaster(int? Id)
        {
            try
            {
                var Data = await _dbContext.InvoiceMasters.Where(o => o.InvoiceId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.InvoiceMasters.Remove(Data);
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
