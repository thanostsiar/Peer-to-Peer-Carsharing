using System.ComponentModel.DataAnnotations;

namespace carsharing.Models
{
    public class Admin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

    }
}
