using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class CreditNote
    {
        public int CreditNoteId { get; set; }

        [ForeignKey(nameof(StaffMaster))]
        public int StaffId { get; set; }

        [ForeignKey(nameof(InvoiceMaster))]
        public int InvoiceId { get; set; }
        public int Amount { get; set; }
        public int NoteNo { get; set; }
        public DateTime NoteDate { get; set; }

      
    }
}
