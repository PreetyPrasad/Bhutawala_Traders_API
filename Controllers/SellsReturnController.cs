using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellsReturnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public SellsReturnController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertSellsReturn")]
        public async Task<IActionResult> AddSellsReturn(SalesReturn salesReturns, int InvoiceId, string PaymentMode, int StaffId)
        {
            try
            {
                double total = 0;

                var returnProducts = salesReturns.SellsReturnDetail.ToList();
                var invoiceDetail = await _dbContext.InvoiceDetails.Where(o => o.InvoiceId == InvoiceId).ToListAsync();

                foreach (var item in returnProducts) {

                    int Id = Convert.ToInt32(item.InvoiceDetailId);
                    var detail = invoiceDetail.Where(o=> o.InvoiceDetailId == Id).FirstOrDefault();
                    total = total + (item.Qty * (detail.Rate + detail.GSTAmount));
                }

                _dbContext.SalesReturns.Add(salesReturns);
                await _dbContext.SaveChangesAsync();

                if (PaymentMode == "Credit Note")
                {
                    int NoteNo = (_dbContext.CreditNotes.DefaultIfEmpty().Max(o => (o != null ? o.NoteNo : 0)) + 1);
                    CreditNote CN = new CreditNote()
                    {
                        Amount = total,
                        InvoiceId = InvoiceId,
                        StaffId = StaffId,
                        NoteNo = NoteNo,
                        NoteDate = DateTime.Now
                    };
                    await _dbContext.SaveChangesAsync();
                }
                
                return Ok(new { Status = "Ok", Result = "Successfully Saved" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }
        [HttpGet]
        [Route("AllSellsReturn")]
        public async Task<IActionResult> getSellsReturn()
        {
            try
            {

                var Data = await (from A in _dbContext.SellsReturnDetails
                                  join B in _dbContext.InvoiceMasters on A.InvoiceId equals B.InvoiceId
                                  join C in _dbContext.InvoiceDetails on A.InvoiceId equals C.InvoiceId
                                  join D in _dbContext.Materials on C.MaterialId equals D.MaterialId
                                  join E in _dbContext.SalesReturns on A.SalesReturnId equals E.SalesReturnId
                                  select new
                                  {
                                      B.InvoiceNo,
                                      B.CustomerName,
                                      B.ContactNo,
                                      B.InvoiceDate,
                                      salesQty = C.Qty,
                                      returnQty = A.Qty,
                                      C.Unit,
                                      C.Rate,
                                      C.GSTAmount,
                                      D.MaterialName,
                                      E.SalesReturnId,
                                      E.Paymentmode,
                                      E.StaffId,
                                      E.RefNo,
                                      E.ReturnDate
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
                var Data = await _dbContext.SellsReturnDetails.Where(o => o.ReturnDetailId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteSellsReturn(int? Id)
        {
            try
            {
                var Data = await _dbContext.SellsReturnDetails.Where(o => o.ReturnDetailId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.SellsReturnDetails.Remove(Data);
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
