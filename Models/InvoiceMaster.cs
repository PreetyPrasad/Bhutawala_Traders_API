using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class InvoiceMaster
    {

        public InvoiceMaster()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            installments = new HashSet<CustomerInstallment>();
        }

        [Key]   
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(StaffMaster))]
        public int? StaffId { get; set; }
        public virtual StaffMaster? StaffMaster { get; set; }


        [ForeignKey(nameof(TransactionYearMaster))]
        public int? TransactionYearId { get; set; }
        public virtual TransactionYearMaster? TransactionYearMaster { get; set; }


        [Required(ErrorMessage = "Invoice Number is required.")]
        
        public int? InvoiceNo { get; set; }

        [Required, StringLength(100, ErrorMessage = "Customer Name cannot exceed 100 characters.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required, RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Contact Number.")]
        public string ContactNo { get; set; } = string.Empty;

        [Required, Range(0, double.MaxValue, ErrorMessage = "Total Gross must be non-negative.")]
        public double TotalGross { get; set; }

       
        public double GST { get; set; }

        [StringLength(50, ErrorMessage = "GST Type cannot exceed 50 characters.")]
        public string? GST_TYPE { get; set; }

        [EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email.")]
        public string? Email { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Total must be non-negative.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Invoice Date is required.")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;
        public DateTime NoticePeriod { get; set; } = DateTime.Now;

        public string? GSTIN { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public ICollection<CustomerInstallment> installments { get; set; }
    }
}
