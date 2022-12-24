using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.CreateTransportation
{
    public class CreateTrnspRequest
    {
        public int requestNumber { get; set; }
        public int numSendingStorage { get; set; }
        public int total_length { get; set; }
        public int car_load { get; set; }
        public int total_shipping_cost { get; set; }
        public string vehicleID { get; set; }
        public string driverID { get; set; }
    }
}
