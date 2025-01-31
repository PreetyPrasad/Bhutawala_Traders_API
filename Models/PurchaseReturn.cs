using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class PurchaseReturn
    {
        [Key]
        public int PurchaseReturnId { get; set; }

        [ForeignKey(nameof(PurchaseMaster))]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(InvoiceMaster))]
        public int InvoiceId { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public double Qty { get; set; }

        [Required, StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string Unit { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Total must be greater than zero.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Return date is required.")]
        public DateTime ReturnDate { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;
    }

}
