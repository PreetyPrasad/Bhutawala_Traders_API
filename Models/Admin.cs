using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class Admin
    {
            [Key]
            public int AdminId { get; set; }

            public string? UserName { get; set; }
            [Required, MinLength(6), RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$", ErrorMessage = "Must have uppercase, number & special char.")]
            public string? Password { get; set; }
            [Required, EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email.")]   
            public string? Email { get; set; }
            [Required, RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Must be 10 digits, start with 6-9.")]             
            public string? ContactNo { get; set; }

            [Required, StringLength(100), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces allowed.")]
            public string? FullName { get; set; }

     }

}
