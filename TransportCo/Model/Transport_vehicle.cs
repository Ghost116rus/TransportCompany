

namespace TransportCo.Model
{
    public class Transport_vehicle
    {
        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public int Transported_volume { get; set; }
        public int Load_capacity { get; set; }
        public float Fuel_consumption { get; set; }
        public string Required_category { get; set; }

    }
}