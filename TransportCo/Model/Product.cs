using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.Model
{
    public class Product
    {
        public string Сatalogue_number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int? Count { get; set; }
    }
}
