using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class CustomerInstallment
    {
        [Key]
        public int InstallmentId { get; set; }

        [ForeignKey(nameof(StaffMaster))]
        public int? StaffId { get; set; }
        public virtual StaffMaster? StaffMaster { get; set; }


        [ForeignKey(nameof(InvoiceMaster))]
        public int? InvoiceId { get; set; }
        public virtual InvoiceMaster? InvoiceMaster { get; set; }


        [Required(ErrorMessage = "Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be non-negative.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Payment Mode is required.")]
        [StringLength(50, ErrorMessage = "Payment Mode cannot exceed 50 characters.")]
        public string Paymentmode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reference Number is required.")]
        [StringLength(100, ErrorMessage = "Reference Number cannot exceed 100 characters.")]
        public string? RefNo { get; set; }

        [Required(ErrorMessage = "Payment Date is required.")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
