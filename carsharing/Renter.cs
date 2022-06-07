namespace carsharing
{
    public class Renter : User
    {
        private int experience;
        public string owner_comment;

        public Renter(string first_name, string last_name, string email, string phone, string image, int age, string password) : base(first_name, last_name, email, phone, image, age, password)
        {
        }
    }
}
