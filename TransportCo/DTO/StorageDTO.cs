using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCo.DTO
{
    public class StorageDTO
    {
        public int Storage_number { get; set; }
        public int LocationId { get; set; }
        public string Addres { get; set; }
        public string Phone_number { get; set; }

        public IEnumerable<ProductForListDTO> Product_Exmps { get; set; } = new List<ProductForListDTO>();
    }
}
