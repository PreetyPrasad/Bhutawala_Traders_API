using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }


        [ForeignKey(nameof(InvoiceMaster))]
        public int? InvoiceId { get; set; }
        public virtual InvoiceMaster? InvoiceMaster { get; set; }



        [ForeignKey(nameof(Material))]
        public int? MaterialId { get; set; }
        public virtual Material? Material { get; set; }



        [Range(0, double.MaxValue, ErrorMessage = "Rate must be non-negative.")]
        public double Rate { get; set; }


        [Required(ErrorMessage = "Quantity is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public double Qty { get; set; }


        [Required(ErrorMessage = "Unit is required.")]
        [StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string Unit { get; set; } = string.Empty;


        [Required(ErrorMessage = "GST Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "GST Amount must be non-negative.")]
        public double GSTAmount { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Total must be non-negative.")]
        public double Total { get; set; }
    }
}
