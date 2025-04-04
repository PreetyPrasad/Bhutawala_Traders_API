﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bhutawala_Traders_API.Models
{
    public class StaffMaster
    {
         [Key]
            public int StaffId { get; set; }

            [ StringLength(100), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only letters and spaces allowed.")]
            public string FullName { get; set; } = string.Empty;

            [ StringLength(200)]
            public string Address { get; set; } = string.Empty;

            [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Must be 10 digits, start with 6-9.")]
            public string ContactNo { get; set; } = string.Empty;
            public string? Category { get; set; }

            [StringLength(100)]
            public string Qualification { get; set; } = string.Empty;

            [RegularExpression(@"^\d{12}$", ErrorMessage = "Must be 12 digits.")]
            public string AdharNo { get; set; } = string.Empty;
    
            [Range(18, 65, ErrorMessage = "Age must be 18-65.")]
            public int Age { get; set; }

            public string? Dj { get; set; }

        [EmailAddress, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; } = string.Empty;

            //[MinLength(6), RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{6,}$",ErrorMessage = "Must have uppercase, number & special char.")]
            public string Password { get; set; } = string.Empty;
    
            public DateTime LogDate { get; set; } = DateTime.Now;
            [NotMapped]
            public string OldPassword {  get; set; }= string.Empty;
            [NotMapped]
            public string NewPassword { get; set; }=string.Empty;
    }
    public class AuthenticationStaff
    {
        public String? FullName { get; set; }
        public String? Password { get; set; }
    }
}
