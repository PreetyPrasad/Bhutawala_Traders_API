using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class SalesReturnDetails
    {
        [Key]
        public int ReturnDetailId { get; set; }

        [ForeignKey(nameof(InvoiceMaster))]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(InwordStock))]
        public int StockId { get; set; }

        [ForeignKey(nameof(InvoiceDetail))]
        public int InvoiceDetailId { get; set; }

        [ForeignKey(nameof(SalesReturn))]
        public int SalesReturnId { get; set; }
     
        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public double Qty { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string? Unit { get; set; }

    }
}
