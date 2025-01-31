using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class DebitNote
    {
        [Key]
        public int NoteID { get; set; }

        [ForeignKey(nameof(PurchaseMaster))]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(StaffMaster))]
        public int StaffId { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Note date is required.")]
        public DateTime NoteDate { get; set; } = DateTime.Now;

        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
