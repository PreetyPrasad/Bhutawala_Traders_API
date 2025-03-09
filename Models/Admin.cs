using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [ StringLength(100), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces allowed.")]
        public string? UserName { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Must be 10 digits, start with 6-9.")]
        public string? ContactNo { get; set; }

        [EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email.")]
        public string? Email { get; set; }

        public string? Password { get; set; }


        [NotMapped]
        public string? oldPasswd { get; set; }
        [NotMapped]
        public string? newPasswd { get; set; }

    }


    public class Authentication
    {
        public String? UserName { get; set; }
        public String? Password { get; set; }
    }

}
