using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class PurchaseReturn
    {
        [Key]
        public int PurchaseReturnId { get; set; }

        [ForeignKey(nameof(PurchaseMaster))]
        public int? PurchaseId { get; set; }
        public virtual PurchaseMaster? PurchaseMaster { get; set; }


        [ForeignKey(nameof(InvoiceMaster))]
        public int? InvoiceId { get; set; }
        public virtual InvoiceMaster? InvoiceMaster { get; set; }
        
        public double Qty { get; set; }
        public string Unit { get; set; } = string.Empty;

        public double Total { get; set; }

        [Required(ErrorMessage = "Return date is required.")]
        public DateTime ReturnDate { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;
    }

}
