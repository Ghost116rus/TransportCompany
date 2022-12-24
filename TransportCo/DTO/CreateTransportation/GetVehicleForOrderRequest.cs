using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.CreateTransportation
{
    public class GetVehicleForOrderRequest
    {
        public string Location { get; set; }
        public int TotalMass { get; set; }
        public int TotalVolume { get; set; }
    }
}
