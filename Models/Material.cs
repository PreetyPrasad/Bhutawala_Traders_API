using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }


        [Required, StringLength(100, ErrorMessage = "Material Name cannot exceed 100 characters.")]
        public string? MaterialName { get; set; }

        [Required, StringLength(50, ErrorMessage = "Unit cannot exceed 50 characters.")]
        public string Unit { get; set; } = string.Empty;

        [Required, Range(0, double.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public double Qty { get; set; }

        [Required, Range(0, double.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public double Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Net Quantity must be non-negative.")]
        public double Net_Qty { get; set; }

        [StringLength(200, ErrorMessage = "Description cannot exceed 200 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(100, ErrorMessage = "Brand cannot exceed 100 characters.")]
        public string Brand { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "GST must be between 0 and 100%.")]
        public double GST { get; set; }

        [Required, StringLength(50, ErrorMessage = "GST Type cannot exceed 50 characters.")]
        public string GST_Type { get; set; } = string.Empty;
    }
}
