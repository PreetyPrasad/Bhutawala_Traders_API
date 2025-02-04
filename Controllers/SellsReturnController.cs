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
        public async Task<IActionResult> AddSellsReturn(List<SellsReturnDetail> sellsReturnDetail, int InvoiceId, string PaymentMode, int StaffId)
        {
            try
            {
                var invoiceDetail = _dbContext.InvoiceDetails.FirstOrDefault(o => o.InvoiceDetailId == InvoiceId);

                if (invoiceDetail == null)
                {
                    return BadRequest(new { Status = "Fail", Result = "Invoice detail not found." });
                }

                var invoiceDetails = await _dbContext.InvoiceDetails.Where(o=> o.InvoiceDetailId == InvoiceId).ToListAsync();
                double total = 0;
                foreach (var list in sellsReturnDetail)
                {
                    var details = invoiceDetails.Where(o => o.InvoiceDetailId == list.InvoiceDetailId && o.Qty <= list.Qty).FirstOrDefault();
                    if (details != null)
                    {
                        total += (list.Qty *  (details.Rate + details.GSTAmount));
                        _dbContext.SellsReturnDetails.Add(list);
                        await _dbContext.SaveChangesAsync();
                    }                    
                }

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

        [HttpPut]
        [Route("EditSellsReturn")]
        public async Task<IActionResult> EditSellsReturn(SellsReturnDetail sellsReturnDetail)
        {
            try
            {
                if (!_dbContext.SellsReturnDetails.Any(o => o.SellsID == sellsReturnDetail.SellsID))
                {
                    _dbContext.SellsReturnDetails.Update(sellsReturnDetail);
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
        [Route("AllSellsReturn")]
        public async Task<IActionResult> getSellsReturn()
        {
            try
            {
                var Data = await _dbContext.SellsReturnDetails.ToListAsync();
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
                var Data = await _dbContext.SellsReturnDetails.Where(o => o.SellsID == Id).FirstOrDefaultAsync();

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
                var Data = await _dbContext.SellsReturnDetails.Where(o => o.SellsID == Id).FirstOrDefaultAsync();

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
