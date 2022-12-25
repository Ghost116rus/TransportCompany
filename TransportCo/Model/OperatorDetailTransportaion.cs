using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.Model
{
    public class OperatorDetailTransportaion
    {
        public int Number { get; set; }
        public DateTime Date_dispatch { get; set; }
        public string Status { get; set; }

        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }

        public string FullName { get; set; }
        public string Phone_number { get; set; }

        public List<Product> Requare_Products { get; set; } = null;
    }
}
