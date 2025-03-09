using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class TransactionYearMaster
    {
        [Key]
        public int TransactionYearId { get; set; }
        [StringLength(20, ErrorMessage = "Year Name cannot exceed 20 characters.")]
        public string? YearName {  get; set; }
        public string? CurrentYear { get; set; }

    }
}
