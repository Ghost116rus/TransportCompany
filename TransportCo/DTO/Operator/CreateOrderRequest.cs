using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO.Operator
{
    public class CreateOrderRequest
    {
        public int num_Receiving_storage { get; set; }
        public int total_volume { get; set; }
        public int total_mass { get; set; }
        public int total_cost { get; set; }

        public IEnumerable<ProductListForRequest> productList { get; set; }
    }
}
