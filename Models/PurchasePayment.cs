using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class PurchasePayment
    {
         [Key]
            public int PaymentId { get; set; }

            [ForeignKey(nameof(PurchaseMaster))]
            public int? PurchaseId { get; set; }
            public virtual PurchaseMaster? PurchaseMaster { get; set; }


            [Required, Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
            public double Amount { get; set; }

            [Required, StringLength(50, ErrorMessage = "Payment Mode cannot exceed 50 characters.")]
            public string? PaymentMode { get; set; }

            [StringLength(100, ErrorMessage = "Reference Number cannot exceed 100 characters.")]
            public string? RefNo { get; set; }

            [Required(ErrorMessage = "Payment date is required.")]
            public DateTime PaymentDate { get; set; } = DateTime.Now;

            public DateTime LogDate { get; set; } = DateTime.Now;
        }
}
