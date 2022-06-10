namespace carsharing.Models
{
    public class Database
    {
        private Database instance;

        private string Select()
        {
            return "O";
        }

        private string InsertInto()
        {
            return "O";
        }
        
        private string Delete()
        {
            return "O";
        }

        private string Update()
        {
            return "O";
        }

        public Database GetInstance()
        {
            return instance;
        }
    }
}
