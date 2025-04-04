using System.Globalization;
using Bhutawala_Traders_API.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;
        public ReportController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }


        [HttpGet]
        [Route("monthlySaleReport")]
        public async Task<IActionResult> MonthlyReport()
        {
            var invoiceDetailQuery = _dbContext.InvoiceDetails
                .Join(_dbContext.InvoiceMasters,
                    a => a.InvoiceId,
                    b => b.InvoiceId,
                    (a, b) => new { a.Total, b.InvoiceDate })
                .GroupBy(x => x.InvoiceDate.Month)
                .Select(g => new
                {
                    TotalAmount = g.Sum(x => x.Total),
                    MonthNumber = g.Key
                });

            var invoiceDetailResult = await invoiceDetailQuery.ToListAsync();

            // Compute month names in memory (client-side)
            var formattedInvoiceDetails = invoiceDetailResult
                .Select(g => new
                {
                    g.TotalAmount,
                    MonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(g.MonthNumber)
                })
                .OrderBy(g => g.MonthName)
                .ToList();

            var totalQty = await _dbContext.InvoiceDetails.SumAsync(a => (int?)a.Qty) ?? 0; // Prevents null exception

            var pieChartResult = await _dbContext.InvoiceDetails
                .Join(_dbContext.Materials,
                    a => a.MaterialId,
                    b => b.MaterialId,
                    (a, b) => new { a.Qty, b.MaterialName })
                .GroupBy(x => x.MaterialName)
                .Select(g => new
                {
                    MaterialName = g.Key,
                    PercentageSold = Math.Round((g.Sum(x => x.Qty) * 100.0) / totalQty, 2)
                })
                .OrderByDescending(g => g.PercentageSold)
                .ToListAsync();

            var financialYearId = await _dbContext.TransactionYearMasters
                .Where(o => o.CurrentYear == "True")
                .Select(o => o.TransactionYearId)
                .FirstOrDefaultAsync();

            var currectSale = await _dbContext.InvoiceDetails
                .Join(_dbContext.InvoiceMasters,
                    a => a.InvoiceId,
                    b => b.InvoiceId,
                    (a, b) => new { a.Total, b.TransactionYearId })
                .Where(x => x.TransactionYearId == financialYearId)
                .SumAsync(x => (decimal?)x.Total) ?? 0;

            var currentPurchase = await _dbContext.PurchaseMasters
                .Where(o => o.TransactionYearId == financialYearId)
                .SumAsync(o => (decimal?)o.Total) ?? 0;

            var customerDues = (await _dbContext.InvoiceMasters.SumAsync(o => (decimal?)o.Total) ?? 0)
                              - (await _dbContext.CustomerInstallments.SumAsync(o => (decimal?)o.Amount) ?? 0);

            var dues = (await _dbContext.PurchaseMasters.SumAsync(o => (decimal?)o.Total) ?? 0)
                      - (await _dbContext.PurchasePayments.SumAsync(o => (decimal?)o.Amount) ?? 0);

            var salesReturn = await _dbContext.SellsReturnDetails.Join(_dbContext.InvoiceDetails,
                                                                        srd => srd.InvoiceDetailId,
                                                                        id => id.InvoiceDetailId,
                                                                        (srd, id) => id.Total).SumAsync(o => (decimal?)o);  // Summing the total values

            var CreditNote = await _dbContext.CreditNotes.SumAsync(o => (decimal?)o.Amount) ?? 0;

            var outwardItems = await (from o in _dbContext.OutwordItems
                                      join m in _dbContext.Materials on o.MaterialId equals m.MaterialId
                                      select o.Qty).SumAsync(qty => (decimal?)qty) ?? 0;

            var paymentReport=await _dbContext.PurchasePayments.Join(_dbContext.PurchaseMasters,
                a => a.PurchaseId,
                b => b.PurchaseId,
                (a, b) => new { a.Amount, b.TransactionYearId })
                .Where(x => x.TransactionYearId == financialYearId)
                .SumAsync(x => (decimal?)x.Amount) ?? 0;

            return Ok(new
            {
                Status = "OK",
                Result = new { invoiceDetailResult = formattedInvoiceDetails, pieChartResult, currectSale, currentPurchase, customerDues, dues,salesReturn ,CreditNote, outwardItems,paymentReport }
            });
        }


    }
}
