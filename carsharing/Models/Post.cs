namespace carsharing.Models
{
    public class Post
    {
        public DateTime date;
        public Vehicle vehicle;
        public Owner owner;
        public string vehicle_description;
        public string vehicle_comments;
        public float vehicle_rating;
        public string title;

        public Post(DateTime date, Vehicle vehicle, Owner owner, string vehicle_description, string vehicle_comments, float vehicle_rating, string title)
        {
            this.date = date;
            this.vehicle = vehicle;
            this.owner = owner;
            this.vehicle_description = vehicle_description;
            this.vehicle_comments = vehicle_comments;
            this.vehicle_rating = vehicle_rating;
            this.title = title;
        }

        public void Create()
        {

        }

        public void Edit()
        {

        }

        public void Delete()
        {

        }
    }
}
