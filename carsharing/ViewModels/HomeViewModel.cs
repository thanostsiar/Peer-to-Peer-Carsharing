using carsharing.Models;

namespace carsharing.ViewModels
{
    public class HomeViewModel
    {
        public Renter? Renter { get; set; }
        public Owner? Owner { get; set; }
        public SearchBar? SearchBar { get; set; }
        public CreatePost? CreatePost { get; set; }
        public Post? Post { get; set; }
        public String? Label { get; set; }
        public String? ErrorMessage { get; set; }
        public IQueryable<Post> Posts { get; set; } = null!;
    }
}
