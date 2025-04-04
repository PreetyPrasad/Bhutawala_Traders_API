using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class OutwordItem
    {
        [Key]
        public int OutwordStockId { get; set; }

        [ForeignKey(nameof(Material))]
        public int MaterialId { get; set; }
        public virtual Material? Material { get; set; }

        [ForeignKey(nameof(OutwordMaster))]
        public int OutwordId { get; set; }
        public virtual OutwordMaster? OutwordMaster { get; set; }
        public int Qty { get; set; }




    }
}
