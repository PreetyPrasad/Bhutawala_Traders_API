using System.ComponentModel.DataAnnotations;

namespace Bhutawala_Traders_API.Models
{
    public class Admin
    {
            [Key]
            public int AdminId { get; set; }

            public string? UserName { get; set; }

            public string? Password { get; set; }

            public string? Email { get; set; }

            public string? ContactNo { get; set; }

            public string? FullName { get; set; }

     }

}
