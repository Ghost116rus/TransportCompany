using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.Model
{
    public class Storage
    {
        public int Number { get; set; }
        public string Addres { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product>? Products { get; set; } = null;
    }
}
