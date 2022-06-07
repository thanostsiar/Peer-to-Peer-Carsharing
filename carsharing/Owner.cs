namespace carsharing
{
    public class Owner : User
    {
        public Owner(string first_name, string last_name, string email, string phone, string image, int age, string password) : base(first_name, last_name, email, phone, image, age, password)
        {
        }
    }
}
