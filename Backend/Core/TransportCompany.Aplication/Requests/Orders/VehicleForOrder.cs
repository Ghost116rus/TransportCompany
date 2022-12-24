using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.Requests.Orders
{
    public class VehicleForOrder
    {
        public string Location { get; set; }
        public int TotalVolume { get; set; }
        public int TotalMass { get; set; }
    }
}
