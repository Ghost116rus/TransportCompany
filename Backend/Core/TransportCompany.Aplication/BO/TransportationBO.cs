
namespace TransportCompany.Aplication.BO
{
    public class TransportationBO
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public DateTime Date_dispatch { get; set; }
        public DateTime Delivery_date { get; set; }
        public int Total_length { get; set; }
        public int Car_load { get; set; }
        public int Total_shipping_cost { get; set; }
        public string Status { get; set; }

        public int RequestNumber { get; set; }

        public string DeliveryAddres { get; set; }


        //public Request Request { get; set; }



        //public string VehicleID { get; set; }


        //public Transport_vehicle vehicle { get; set; }


    }
}