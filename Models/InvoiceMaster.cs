using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class InvoiceMaster
    {
      
            [Key]   
            public int InvoiceId { get; set; }
            [ForeignKey(nameof(StaffMaster))]
             public int StaffId { get; set; }

            [Required(ErrorMessage = "Invoice Number is required.")]
            public int InvoiceNo { get; set; }

            [Required, StringLength(100, ErrorMessage = "Customer Name cannot exceed 100 characters.")]
            public string CustomerName { get; set; } = string.Empty;

            [Required, RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Contact Number.")]
            public string ContactNo { get; set; } = string.Empty;

            [Required, Range(0, double.MaxValue, ErrorMessage = "Total Gross must be non-negative.")]
            public double TotalGross { get; set; }

            [Required, Range(0, 100, ErrorMessage = "GST must be between 0 and 100%.")]
            public double GST { get; set; }

            [StringLength(50, ErrorMessage = "GST Type cannot exceed 50 characters.")]
            public string? GST_TYPE { get; set; }

            [Required, Range(0, double.MaxValue, ErrorMessage = "Total must be non-negative.")]
            public double Total { get; set; }

            [Required(ErrorMessage = "Invoice Date is required.")]
            public DateTime InvoiceDate { get; set; } = DateTime.Now;

            public DateTime NoticePeriod { get; set; } = DateTime.Now;

            [RegularExpression(@"^\d{15}$", ErrorMessage = "GSTIN must be exactly 15 characters.")]
            public string? GSTIN { get; set; }
        }
}
