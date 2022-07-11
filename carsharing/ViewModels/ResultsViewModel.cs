using carsharing.Models;

namespace carsharing.ViewModels
{
    public class ResultsViewModel
    {
        public SearchBar SearchBar;

        public FilterPost FilterPost;

        public String ErrorMessage;

        public double NumberOfDays;

        public IQueryable<Post> Posts { get; set; } = null!;

        public ResultsViewModel(IQueryable<Post> post, double numberOfDays, String errorMessage = "")
        {
            this.SearchBar = new SearchBar();
            this.FilterPost = new FilterPost();
            this.Posts = post;
            this.NumberOfDays = numberOfDays;
            this.ErrorMessage = errorMessage;
        }


    }

}
