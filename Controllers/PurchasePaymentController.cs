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
        [Route("Save")]
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
        [Route("List")]
        public async Task<IActionResult> getPurchasePayment()
        {
            try
            {
                var Data = await (from A in _dbContext.PurchaseMasters
                                  join B in _dbContext.Suppliers on A.SupplierId equals B.SupplierId
                                  select new
                                  {
                                      A.PurchaseId,
                                      A.Total,
                                      Paid = (_dbContext.PurchasePayments.DefaultIfEmpty().Where(o=> o.PurchaseId == A.PurchaseId).Sum(o=> (o != null ? o.Amount : 0))),
                                      B.BusinessName,
                                      A.SupplierId,
                                      A.GST_Type,
                                      A.PurchaseDate,
                                      A.BillNo,
                                      A.NoticePeriod
                                  }).ToListAsync();
                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("PurchasePayments/{PurchaseId}")]
        public async Task<IActionResult> getPurchasePayments(int PurchaseId)
        {
            try
            {
                var Data = await _dbContext.PurchasePayments.Where(o => o.PurchaseId == PurchaseId).ToListAsync();
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

                var Data = await (from A in _dbContext.PurchaseMasters
                                  join B in _dbContext.Suppliers on A.SupplierId equals B.SupplierId
                                  select new
                                  {
                                      A.PurchaseId,
                                      Paid = _dbContext.PurchasePayments.DefaultIfEmpty().Where(A => A.PurchaseId == A.PurchaseId).Sum(o => (o != null ? o.Amount : 0)),
                                      A.GST,
                                      B.BusinessName,
                                  }).FirstOrDefaultAsync();

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
