using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.BO
{
    public class RequestChangeStatusTransportation
    {
        public int TransportationNumber { get; set; }
        public string Status { get; set; }
    }
}
