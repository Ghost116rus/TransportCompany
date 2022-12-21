using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.BO
{
    public class DetailTransportationBO
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Status { get; set; }
        public string Sending_storage_Addres { get; set; }
        public DateTime Date_dispatch { get; set; }

        public string DeliveryAddres { get; set; }

        public int Total_length { get; set; }
        public int Total_shipping_cost { get; set; }



        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }
        public int Car_load { get; set; }


        public string FullName { get; set; }
        public string Driver_license_number { get; set; }
        public DateTime Delivery_date { get; set; }

        public int RequestNumber { get; set; }
    }
}
