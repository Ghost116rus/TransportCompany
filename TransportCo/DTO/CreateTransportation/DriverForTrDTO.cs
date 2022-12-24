using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.CreateTransportation
{
    public class DriverForTrDTO
    {
        public string Driver_license_number { get; set; }
        public string Fullname { get; set; }
        public int CountOfTransportation { get; set; }
        public int Expirience { get; set; }
    }
}
