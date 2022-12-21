using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO
{
    public class DriverDTO
    {
        public string Driver_license_number { get; set; }
        public string FIO { get; set; }
        public string Addres { get; set; }
        public string Phone_number { get; set; }
        public string Driver_license_category { get; set; }
        public string Expirience { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }

        public IEnumerable<TRansportationDTO> Transportations { get; set; } = new List<TRansportationDTO>();
    }
}
