using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class InwordStock
    {
        [Key]
        public int StockId { get; set; }

        [ForeignKey(nameof(Material))]
        public int MaterialId { get; set; }

        [ForeignKey(nameof(PurchaseMaster)) ]
        public int PurchaseId { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public double Qty { get; set; }

        [Required, StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string Unit { get; set; } = string.Empty;

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Cost must be greater than zero.")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Received Date is required.")]
        public DateTime RecivedDate { get; set; } = DateTime.Now;

        [StringLength(200, ErrorMessage = "Note cannot exceed 200 characters.")]
        public string? Note { get; set; }

        [Required(ErrorMessage = "Staff ID is required.")]
        public int StaffId { get; set; }
    }
}
