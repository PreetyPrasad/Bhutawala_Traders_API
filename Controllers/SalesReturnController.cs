using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesReturnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public SalesReturnController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
         public async Task<IActionResult> Add(SalesReturn salesReturn)
         {
             try
             {
                _dbContext.SalesReturns.Add(salesReturn);
                await _dbContext.SaveChangesAsync();

                if (salesReturn.ReturnAmount > 0 && salesReturn.Paymentmode == "Credit Note")
                {
                    CreditNote creditNote = new CreditNote()
                    {
                        Amount = salesReturn.ReturnAmount,
                        InvoiceId = salesReturn.InvoiceId,
                        StaffId = salesReturn.StaffId,
                    };
                    _dbContext.CreditNotes.Add(creditNote);
                    await _dbContext.SaveChangesAsync();
                }


                var creditNoteId = _dbContext.SalesReturns.Max(o => o.SalesReturnId);

                return Ok(new { Status = "Ok", Result = creditNoteId });
            }
             catch (Exception ex)
             {
                 return BadRequest(new { Status = "Fail", Result = ex.Message });
             }
         }

         [HttpPut]
         [Route("Edit")]
         public async Task<IActionResult> EditSalesReturn(SalesReturn salesReturn)
         {
             try
             {
                 if (!_dbContext.SalesReturns.Any(o => o.SalesReturnId == salesReturn.SalesReturnId))
                 {
                     _dbContext.SalesReturns.Update(salesReturn);
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
         [Route("List")]
         public async Task<IActionResult> get()
         {
             try
             {
                var Data = await (from A in _dbContext.SalesReturns
                                  join B in _dbContext.InvoiceMasters on A.InvoiceId equals B.InvoiceId
                                  join C in _dbContext.Materials on A.InvoiceId equals C.MaterialId
                                  where A.SalesReturnId== A.SalesReturnId
                                  select new
                                  {
                                      C.MaterialName,
                                      A.SalesReturnId,
                                      A.ReturnDate,
                                      A.BillReturnAmount,
                                      A.ReturnAmount,
                                      B.InvoiceNo,
                                      B.InvoiceDate,
                                      B.CustomerName,
                                      B.ContactNo,
                                      B.Total,
                                      A.Paymentmode,
                                      A.StaffId,
                                      
                                  }).ToListAsync();
                //var Data = await _dbContext.SalesReturns.ToArrayAsync();
                return Ok(new { Status = "OK", Result = Data });
            }
             catch (Exception ex)
             {
                 return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
             }
         }


        [HttpGet]
        [Route("Print/{Id}")]
        public async Task<IActionResult> SalesReturnPrint(int Id)
        {
            try
            {
                var data = await (from A in _dbContext.SalesReturns
                                  join B in _dbContext.InvoiceMasters on A.InvoiceId equals B.InvoiceId
                                  where A.SalesReturnId == Id
                                  select new
                                  {
                                      B.InvoiceDate,
                                      B.InvoiceNo,
                                      A.ReturnDate,
                                      A.BillReturnAmount,
                                      A.ReturnAmount,
                                      B.Total,
                                      A.Paymentmode,
                                      B.CustomerName,
                                      returProducts = (from C in _dbContext.SellsReturnDetails
                                                       join D in _dbContext.Materials on C.MaterialId equals D.MaterialId
                                                       join E in _dbContext.InvoiceDetails on C.InvoiceDetailId equals E.InvoiceDetailId
                                                       join F in _dbContext.Categories on D.CategoryId equals F.CategoryId
                                                       where C.SalesReturnId == Id
                                                       select new
                                                       {
                                                           F.CategoryName,
                                                           D.MaterialName,
                                                           D.GST,
                                                           E.Rate,
                                                           C.Qty,
                                                           E.Unit,
                                                           E.GSTAmount,
                                                           Total = C.Qty * (E.Rate + E.GSTAmount)
                                                       }).ToList(),
                                    invoicePayments = _dbContext.CustomerInstallments.Where(I => I.InvoiceId == B.InvoiceId).ToList(),
                                    creditNote = _dbContext.CreditNotes.Where(I => I.InvoiceId == B.InvoiceId).FirstOrDefault(),
                                  }).FirstOrDefaultAsync();
                return Ok(new { Status = "OK", Result = data });

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }



            [HttpGet]
         [Route("Details/{InvoiceNo}/{BillDate}")]
        public async Task<IActionResult> getDetails(int InvoiceNo,DateTime BillDate)
        {
            try
            {   
                var Data = await _dbContext.InvoiceMasters
                                           .Where(o => o.InvoiceNo == InvoiceNo && o.InvoiceDate.Date == BillDate.Date)
                                           .Select(o => new
                                           {
                                               invoicePayment = _dbContext.CustomerInstallments.Where(I=> I.InvoiceId == o.InvoiceId).ToList(),
                                               invoiceDetail = (from A in _dbContext.InvoiceDetails
                                                                join B in _dbContext.Materials on A.MaterialId equals B.MaterialId
                                                                join C in _dbContext.Categories on B.CategoryId equals C.CategoryId
                                                                join D in _dbContext.InvoiceMasters on A.InvoiceId equals D.InvoiceId
                                                                where (A.InvoiceId == o.InvoiceId)
                                                                select new
                                                                {
                                                                    B.MaterialId,
                                                                    B.MaterialName,
                                                                    B.GST,
                                                                    A.InvoiceDetailId,
                                                                    A.Rate,
                                                                    A.Qty,
                                                                    A.Unit,
                                                                    A.GSTAmount,
                                                                    A.Total,
                                                                    C.CategoryName,
                                                                    B.GST_Type,
                                                                   D.StaffId
                                                                }).ToList(),
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

        [HttpGet]
         [Route("Remove/{Id}")]
         public async Task<IActionResult> delete(int? Id)
         {
             try
             {
                 var Data = await _dbContext.SalesReturns.Where(o => o.SalesReturnId == Id).FirstOrDefaultAsync();

                 if (Data != null)
                 {
                     _dbContext.SalesReturns.Remove(Data);
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

