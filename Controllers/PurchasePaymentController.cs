using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasePaymentController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PurchasePaymentController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Insert PurchasePayment")]
        public async Task<IActionResult> AddPurchasePayment(PurchasePayment purchasePayment)
        {
            try
            {
                if (!_dbContext.PurchasePayments.Any(o => o.PaymentId == purchasePayment.PaymentId))
                {
                    _dbContext.PurchasePayments.Add(purchasePayment);
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
        
        [HttpGet]
        [Route("AllPurchasePayment")]
        public async Task<IActionResult> getPurchasePayment()
        {
            try
            {
                var Data = await _dbContext.PurchasePayments.ToArrayAsync();
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
                var Data = await _dbContext.PurchasePayments.Where(o => o.PurchaseId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deletePurchasePayment(int? Id)
        {
            try
            {
                var Data = await _dbContext.PurchasePayments.Where(o => o.PurchaseId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.PurchasePayments.Remove(Data);
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
