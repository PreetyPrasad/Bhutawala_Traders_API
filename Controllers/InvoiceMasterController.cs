using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [Route("Save")]
        public async Task<IActionResult> AddInvoiceMaster(InvoiceMaster invoiceMaster)
        {
            try
            {
                // Validate TransactionYearId
                invoiceMaster.TransactionYearId = await _dbContext.TransactionYearMasters
                    .Where(o => o.CurrentYear == "True")
                    .Select(o => o.TransactionYearId)
                    .FirstOrDefaultAsync();

                if (invoiceMaster.TransactionYearId == 0)
                {
                    return BadRequest(new { Status = "Fail", Result = "Transaction Year ID not found." });
                }

                _dbContext.InvoiceMasters.Add(invoiceMaster);
                await _dbContext.SaveChangesAsync();

                // Check installments
                var customerInstallments = invoiceMaster.installments;
                foreach (var installment in customerInstallments)
                {
                    if (installment.Paymentmode == "Credit Note")
                    {
                        if (!int.TryParse(installment.RefNo, out int CreditNoteId))
                        {
                            return BadRequest(new { Status = "Fail", Result = "Invalid Credit Note Reference Number." });
                        }

                        var InvoiceId = invoiceMaster.InvoiceId; // Use the assigned InvoiceId
                        ApplyCredit AC = new ApplyCredit()
                        {
                            StaffId = invoiceMaster.StaffId,
                            CreditNoteId = CreditNoteId,
                            InvoiceId = InvoiceId,
                            LogDate = DateTime.Now
                        };

                        _dbContext.ApplyCredits.Add(AC);
                        await _dbContext.SaveChangesAsync();
                    }
                }

                return Ok(new { Status = "Ok", Result = "Successfully Saved" });
            }
            catch (DbUpdateException dbEx)
            {
                // Capture database-specific error
                return BadRequest(new { Status = "Fail", Result = "Database Error: " + dbEx.InnerException?.Message });
            }
            catch (Exception ex)
            {
                // Capture general error
                return BadRequest(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }


        [HttpGet]
        [Route("List/{FinancialYear}")]
        public async Task<IActionResult> getInvoiceMaster(int FinancialYear)
        {
            try
            {
                var Data = await _dbContext.InvoiceMasters.Where(o=> o.TransactionYearId == FinancialYear).ToArrayAsync();
                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }

        [HttpGet]
        [Route("MaxNo")]
        public async Task<IActionResult> GetNextInvoiceNo()
        {
            try
            {
                // Fetch the max InvoiceNo for the given Id (e.g., SupplierId, PurchaseId, etc.)
                var maxInvoice = await _dbContext.InvoiceMasters
                                               .Where(p => p.TransactionYearId == _dbContext.TransactionYearMasters.Where(o=> o.CurrentYear == "True").Select(o=> o.TransactionYearId).FirstOrDefault()) 
                                               .MaxAsync(p => (int?)p.InvoiceNo) ?? 0;

                // Auto-increment the InvoiceNo
                int nextInvoiceNo = maxInvoice + 1;
                return Ok(new { Status = "OK", Result = nextInvoiceNo });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<IActionResult> getDetails(int? Id)
        {
            try
            {
                
                var invoiceDetail = await (from A in _dbContext.InvoiceDetails 
                                  join B in _dbContext.Materials on A.MaterialId equals B.MaterialId
                                  where (A.InvoiceId == Id)
                                  select new
                                  {
                                      A.InvoiceId,
                                      B.MaterialName,
                                      A.InvoiceDetailId,
                                      A.Rate,
                                      A.Qty,
                                      A.Unit,
                                      A.GSTAmount,
                                      A.Total
                                  }).ToListAsync();

                var Data = await _dbContext.InvoiceMasters
                                           .Where(o => o.InvoiceId == Id)
                                           .Select(o=> new
                                           {
                                               invoiceDetail = invoiceDetail,
                                               o.InvoiceId,
                                               o.InvoiceNo,
                                               o.CustomerName,
                                               o.ContactNo,
                                               o.TotalGross,
                                               o.GST,
                                               o.GST_TYPE,
                                               o.Total,
                                               o.InvoiceDate,
                                               o.NoticePeriod,
                                               o.GSTIN,
                                               o.StaffId,
                                               o.TransactionYearId
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
    }
}
