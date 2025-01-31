using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInstallmentController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerInstallmentController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertCustomerInstallment")]
        public async Task<IActionResult> AddCustomerInstallment(CustomerInstallment customerInstallment)
        {
            try
            {
                var billDetail = await _dbContext.InvoiceMasters.FindAsync(customerInstallment.InvoiceId);
                var totalAmount = await _dbContext.CustomerInstallments.DefaultIfEmpty().SumAsync(o => (o != null ? o.Amount : 0));

                if (billDetail != null) {
                    if ((totalAmount + customerInstallment.Amount) <= billDetail.Total)
                    {
                        _dbContext.CustomerInstallments.Add(customerInstallment);
                        await _dbContext.SaveChangesAsync();
                        return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                    }
                    else
                    {
                        return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                    }
                }
                else
                {
                    return NotFound (new { Status = "Fail", Result = "Bill Detail not found" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }

        [HttpPut]
        [Route("EditCustomerInstallment")]
        public async Task<IActionResult> EditCustomerInstallment(CustomerInstallment customerInstallment)
        {
            try
            {
                if (!_dbContext.CustomerInstallments.Any(o => o.InstallmentId == customerInstallment.InstallmentId))
                {
                    _dbContext.CustomerInstallments.Update(customerInstallment);
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
        [Route("AllCustomerInstallment")]
        public async Task<IActionResult> getCustomerInstallment()
        {
            try
            {
                var Data = await _dbContext.CustomerInstallments.ToArrayAsync();
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
                var Data = await _dbContext.CustomerInstallments.Where(o => o.InstallmentId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteCustomerInstallments(int? Id)
        {
            try
            {
                var Data = await _dbContext.CustomerInstallments.Where(o => o.InstallmentId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.CustomerInstallments.Remove(Data);
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
