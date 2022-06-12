using System.ComponentModel.DataAnnotations;

namespace carsharing.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; } = null!;
    }
}
