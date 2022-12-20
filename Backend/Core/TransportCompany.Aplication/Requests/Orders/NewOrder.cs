using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Aplication.Requests.Orders
{
    public class NewOrder
    {
        public int Num_Receiving_storage { get; set; }
        public int Total_volume { get; set; }
        public int Total_mass { get; set; }
        public int Total_cost { get; set; }
        public IList<ProductList> productList { get; set; }
    }
}
