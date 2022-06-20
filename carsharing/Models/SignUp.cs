using System.ComponentModel.DataAnnotations;

namespace carsharing.Models
{
    public class SignUp
    {
        [Required(ErrorMessage = "Please enter your first name!")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your last name!")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your age!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Please confirm your password!")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "Please enter your email address!")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Please enter phone!")]
        public string Phone { get; set; } = null!;
    }
}
