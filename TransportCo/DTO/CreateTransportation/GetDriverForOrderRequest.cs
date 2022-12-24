using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.CreateTransportation
{
    public class GetDriverForOrderRequest
    {
        public string Location { get; set; }
        public string Required_category { get; set; }

    }
}
