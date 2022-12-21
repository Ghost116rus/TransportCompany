using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.Requests.CreateTransportation
{
    public class RequestToCreateTransportation
    {
        public int RequestNumber { get; set; }
        public int NumSendingStorage { get; set; }
        public int Total_length { get; set; }
        public int Car_load { get; set; }
        public int Total_shipping_cost { get; set; }
        public string VehicleID { get; set; }
        public string DriverID { get; set; }
    }
}
