using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Business Name is required.")]
        [StringLength(100, ErrorMessage = "Business Name cannot exceed 100 characters.")]
        public string? BusinessName { get; set; }

        [Required(ErrorMessage = "Contact Person is required.")]
        [StringLength(100, ErrorMessage = "Contact Person cannot exceed 100 characters.")]
        public string? ContactPerson { get; set; }

        [Required(ErrorMessage = "Contact Number is required.")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Contact Number.")]
        public string? ContactNo { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "State cannot exceed 100 characters.")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pin Code must be 6 digits.")]
        public string? PinCode { get; set; }

        [StringLength(15, ErrorMessage = "GSTIN cannot exceed 15 characters.")]
        public string? GSTIN { get; set; }

        [StringLength(10, ErrorMessage = "PAN cannot exceed 10 characters.")]
        public string? PAN { get; set; }

        [StringLength(100, ErrorMessage = "Bank Branch cannot exceed 100 characters.")]
        public string? BanckBranch { get; set; }

        [StringLength(11, ErrorMessage = "IFSC cannot exceed 11 characters.")]
        public string? IFSC { get; set; }

        [StringLength(20, ErrorMessage = "Account Number cannot exceed 20 characters.")]
        public string? AccountNo { get; set; }

        [Required(ErrorMessage = "Bank Name is required.")]
        [StringLength(100, ErrorMessage = "Bank Name cannot exceed 100 characters.")]
        public string? BankName { get; set; }

        [Required(ErrorMessage = "Log Date is required.")]
        public DateTime LogDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }
    }
}
