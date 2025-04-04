﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class ApplyCredit
    {
        [Key]
        public int ApplyId { get; set; }

        
        [ForeignKey(nameof(StaffMaster))]
        public int? StaffId { get; set; }
        public virtual StaffMaster? StaffMaster { get; set; }

        
        [ForeignKey(nameof(CreditNote))]
        public int? CreditNoteId { get; set; }
        public virtual CreditNote? CreditNote { get; set; }


        [ForeignKey(nameof(InvoiceMaster))]
        public int? InvoiceId { get; set; }
        public virtual InvoiceMaster? InvoiceMaster { get; set; }


        [Required(ErrorMessage = "Log Date is required.")]
        public DateTime LogDate { get; set; } = DateTime.Now;
    }
}
