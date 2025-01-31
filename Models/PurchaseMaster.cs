using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class PurchaseMaster
    {
        [Key]
        public int PurchaseId { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Gross Total must be non-negative.")]
        public double GrossTotal { get; set; }

        [Required, Range(0, 100, ErrorMessage = "GST must be between 0 and 100%.")]
        public double GST { get; set; }

        [StringLength(50, ErrorMessage = "GST Type cannot exceed 50 characters.")]
        public string? GST_Type { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Total must be non-negative.")]
        public double Total { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        [StringLength(100, ErrorMessage = "Bill Number cannot exceed 100 characters.")]
        public string? BillNo { get; set; }

        [Required(ErrorMessage = "Notice Period is required.")]
        public DateTime NoticePeriod { get; set; }

        [StringLength(200, ErrorMessage = "Note cannot exceed 200 characters.")]
        public string? Note { get; set; }
    }
}
