using System.ComponentModel.DataAnnotations;

namespace carsharing.Models
{
    public class SearchBar
    {
        [Required(ErrorMessage = "Please enter ")]

        // TODO: need to check if DateFrom is less than Date.Today
        // if that's true, then don't accept the request
        private string DateFrom { get; set; } = null!;

        [Required(ErrorMessage = "Please enter ")]
        private string DateTo { get; set; } = null!;

        [Required(ErrorMessage = "Please enter ")]

        // TODO: need to check if TimeFrom is less than Time.Now
        // if that's true, then don't accept the request
        private string TimeFrom { get; set; } = null!;

        [Required(ErrorMessage = "Please enter ")]
        private string TimeTo { get; set; } = null!;
    }
}
