using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO
{
    public class TRansportationDTO
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public DateTime Date_dispatch { get; set; }
        public DateTime Delivery_date { get; set; }
        public string DeliveryAddres { get; set; }
        public string FullName { get; set; }
        public int RequestNumber { get; set; }
        public string Driver_license_number { get; set; }
    }
}
