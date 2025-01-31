using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public InvoiceDetailController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertInvoiceDetail")]
        public async Task<IActionResult> AddInvoiceDetail(InvoiceDetail InvoiceDetail)
        {
            try
            {
                if (!_dbContext.InvoiceDetails.Any(o => o.InvoiceDetailId == InvoiceDetail.InvoiceDetailId))
                {
                    _dbContext.InvoiceDetails.Add(InvoiceDetail);
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
        [Route("EditInvoiceDetail")]
        public async Task<IActionResult> EditInvoiceDetail(InvoiceDetail InvoiceDetail)
        {
            try
            {
                if (!_dbContext.InvoiceDetails.Any(o => o.InvoiceDetailId == InvoiceDetail.InvoiceDetailId))
                {
                    _dbContext.InvoiceDetails.Update(InvoiceDetail);
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
        [Route("AllInvoiceDetail")]
        public async Task<IActionResult> getInvoiceDetail()
        {
            try
            {
                var Data = await _dbContext.InvoiceDetails.ToArrayAsync();
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
                var Data = await _dbContext.InvoiceDetails.Where(o => o.InvoiceDetailId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteInvoiceDetail(int? Id)
        {
            try
            {
                var Data = await _dbContext.InvoiceDetails.Where(o => o.InvoiceDetailId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.InvoiceDetails.Remove(Data);
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
