﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class SalesReturn
    {
        public SalesReturn()
        {
            SellsReturnDetail = new HashSet<SalesReturnDetails>();
        }

        [Key]
        public int SalesReturnId { get; set; }

        [ForeignKey(nameof(InvoiceMaster))]
        public int? InvoiceId { get; set; }
        public virtual InvoiceMaster? InvoiceMaster { get; set; }


        [Required(ErrorMessage = "Payment Mode is required.")]
        [StringLength(50, ErrorMessage = "Payment Mode cannot exceed 50 characters.")]
        public string Paymentmode { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "Reference Number cannot exceed 100 characters.")]
        public string? RefNo { get; set; }
        public DateTime ReturnDate { get; set; } = DateTime.Now;

        public double BillReturnAmount { get; set; }
        public double ReturnAmount { get; set; }

        [ForeignKey(nameof(StaffMaster))]
        public int? StaffId { get; set; }
        public virtual StaffMaster? StaffMaster { get; set; }
       
        public ICollection<SalesReturnDetails> SellsReturnDetail { get; set; }

    }
}
