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
                var invoiceNo = (_dbContext.InvoiceMasters
                                           .Where(o=> o.TransactionYearId == invoiceMaster.TransactionYearId)
                                           .DefaultIfEmpty()
                                           .Max(o=> (o != null ? o.InvoiceNo : 0)) + 1);

                invoiceMaster.InvoiceNo = invoiceNo;
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

        [HttpGet]
        [Route("AllInvoiceMaster/{FinancialYear}")]
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
