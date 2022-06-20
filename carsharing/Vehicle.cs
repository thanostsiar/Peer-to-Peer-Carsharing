namespace carsharing
{
    public class Vehicle
    {
        public string vehicle_img;
        public string vehicle_model;
        public int vehicle_cc;
        public int vehicle_yor;
        public string vehicle_location;
        public bool vehicle_availability;

        public Vehicle(string vehicle_img, string vehicle_model, int vehicle_cc, int vehicle_yor, string vehicle_location, bool vehicle_availability)
        {
            this.vehicle_img = vehicle_img;
            this.vehicle_model = vehicle_model;
            this.vehicle_cc = vehicle_cc;
            this.vehicle_yor = vehicle_yor;
            this.vehicle_location = vehicle_location;
            this.vehicle_availability = vehicle_availability;
        }
    }
}
