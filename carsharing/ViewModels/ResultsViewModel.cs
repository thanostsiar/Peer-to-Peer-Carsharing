using carsharing.Models;

namespace carsharing.ViewModels
{
    public class ResultsViewModel
    {
        public SearchBar SearchBar;

        public String ErrorMessage;

        public IQueryable<Vehicle> Vehicles { get; set; } = null!;

        public IQueryable<Post> Posts { get; set; } = null!;

        public ResultsViewModel(IQueryable<Vehicle> vehicles, IQueryable<Post> post, String errorMessage = "")
        {
            this.SearchBar = new SearchBar();
            this.Vehicles = vehicles;
            this.Posts = post;
            this.ErrorMessage = errorMessage;
        }
    }

}
