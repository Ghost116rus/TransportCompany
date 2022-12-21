using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO
{
    public class OrderDTO
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public int Num_Receiving_storage { get; set; }
        public string Addres { get; set; }
        public int Total_volume { get; set; }
        public int Total_mass { get; set; }
        public int Total_cost { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime? DateOfComplete { get; set; }
        public int TransportationNumber { get; set; }
        public IEnumerable<ProductForListDTO>? productsList { get; set; }
        public string Driver_license_number { get; set; }

    }
}
