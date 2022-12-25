using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.BO
{
    public class DetailTransportationForOperatorBO
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Status { get; set; }
        public DateTime Date_dispatch { get; set; }

        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }

        public string FullName { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<ProductExmpBO>? productsList { get; set; }
    }
}
