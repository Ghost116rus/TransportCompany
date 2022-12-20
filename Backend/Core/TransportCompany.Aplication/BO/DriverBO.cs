using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.BO
{
    public class DriverBO
    {
        public string Driver_license_number { get; set; }
        public string FIO { get; set; }
        public string Addres { get; set; }
        public string Phone_number { get; set; }
        public string Driver_license_category { get; set; }
        public string Expirience { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public IEnumerable<TransportationBO> Transportations { get; set; } = new List<TransportationBO>();
    }
}
