using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

    }
}
