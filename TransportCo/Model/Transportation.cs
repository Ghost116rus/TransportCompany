using System;

namespace TransportCo.Model
{
    public class Transportation
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Sending_storage_Addres { get; set; }
        public DateTime Date_dispatch { get; set; }
        public DateTime Delivery_date { get; set; }
        public int Total_time { get; set; }
        public int Total_length { get; set; }
        public int Car_load { get; set; }
        public int Total_shipping_cost { get; set; }
        public string Status { get; set; }
        public Transport_vehicle vehicle { get; set; }
        public Driver driver { get; set; }
    }
}