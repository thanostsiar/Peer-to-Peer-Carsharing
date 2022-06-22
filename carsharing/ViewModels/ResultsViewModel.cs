using carsharing.Models;

namespace carsharing.ViewModels
{

    public class ResultsViewModel
    {
        public IQueryable<Vehicle> Vehicles { get; set; } = null!;

        public IQueryable<Post> Posts { get; set; } = null!;

        public ResultsViewModel(IQueryable<Vehicle> vehicles, IQueryable<Post> post)
        {
            this.Vehicles = vehicles;
            this.Posts = post;
        }
    }

}
