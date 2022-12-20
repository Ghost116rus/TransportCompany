using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TransportCompany.Aplication.BO
{
    public class ProductBO
    {
        public string Сatalogue_number { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Cost { get; set; }


        //public IEnumerable<Requare_productBO> Requare_Products { get; set; } = new List<Requare_product>();

        //public IEnumerable<Product_exmp> Product_Exmps { get; set; } = new List<Product_exmp>();

    }
}
