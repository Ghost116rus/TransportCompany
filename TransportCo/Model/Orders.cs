using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.Model
{
    public class Orders
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public int Total_volume { get; set; }
        public int Total_mass { get; set; }
        public int Total_cost { get; set; }

        public string NameOfOperator { get; set; }

        public DateTime DateOfCreate { get; set; }
        public DateTime DateOfComplete { get; set; }

        public int Num_Receiving_storage { get; set; }
        public string Addres { get; set; }

        public Transportation? transportation { get; set; }
        public List<Product> Requare_Products { get; set; } = new List<Product>();
    }
}
