using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class TransactionYearMaster
    {
        [Key]
        public int TransactionYearId { get; set; }
        public string? YearName {  get; set; }
    }
}
