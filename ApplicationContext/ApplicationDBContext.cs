using Bhutawala_Traders_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.ApplicationContext
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseMaster> PurchaseMasters { get; set; }
        public DbSet<InwordStock> Inwordstocks { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<InvoiceMaster> InvoiceMasters { get; set; }
        public DbSet<CreditNote> CreditNotes { get; set; }
        public DbSet<ApplyCredit> ApplyCredits { get; set; }
        public DbSet<StaffMaster> StaffMasters { get; set; }
        public DbSet<PurchasePayment> PurchasePayments { get; set; }
        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<DebitNote> DebitNotes { get; set; }
        public DbSet<CustomerInstallment> CustomerInstallments { get; set; }
        public DbSet<SalesReturnDetails> SellsReturnDetails { get; set; }
        public DbSet<TransactionYearMaster>TransactionYearMasters { get; set; }
        public DbSet<SalesReturn> SalesReturns { get; set; }
    }
}
