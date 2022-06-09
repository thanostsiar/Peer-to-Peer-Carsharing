namespace carsharing.Models
{
    public class User
    {
        protected string first_name { get; }
        protected string last_name;
        protected string email;
        protected string phone;
        public float rating;
        protected string image;
        protected int age;
        protected int user_id;
        protected string password;

        public User(string first_name, string last_name, string email, string phone, string image, int age, string password)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.email = email;
            this.phone = phone;
            this.image = image;
            this.age = age;
            this.password = password;
        }

    }
}
