using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class OutwordMaster
    {
        public OutwordMaster()
        {
            OutwordItems = new HashSet<OutwordItem>();

        }

        [Key]
        public int OutwordId { get; set; }
        [ForeignKey(nameof(StaffMaster))]
        public int StaffId { get; set; }
        public virtual StaffMaster? StaffMaster { get; set; }

        public string Reason { get; set; } = string.Empty;
        public string Givento { get; set; } = string.Empty;
        public string ContactNo { get; set; } = string.Empty;
        public DateTime OutwordDate { get; set; } = DateTime.Now;

        public ICollection<OutwordItem> OutwordItems { get; set; }


    }
}
