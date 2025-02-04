using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class SalesReturn
    {
        public SalesReturn()
        {
            SellsReturnDetail = new HashSet<SalesReturnDetails>();
        }

        [Key]
        public int SalesReturnId { get; set; }
        [ForeignKey(nameof(InvoiceMaster))]
        public int InvoiceId { get; set; }
        [Required(ErrorMessage = "Payment Mode is required.")]
        [StringLength(50, ErrorMessage = "Payment Mode cannot exceed 50 characters.")]
        public string Paymentmode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reference Number is required.")]
        [StringLength(100, ErrorMessage = "Reference Number cannot exceed 100 characters.")]
        public string? RefNo { get; set; }

        public DateTime ReturnDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(StaffMaster))]
        public int StaffId { get; set; }

        public ICollection<SalesReturnDetails> SellsReturnDetail { get; set; }

    }
}
