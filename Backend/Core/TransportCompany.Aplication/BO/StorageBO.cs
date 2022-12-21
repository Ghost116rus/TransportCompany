using TransportCompany.Domain.Entities;

namespace TransportCompany.Aplication.BO
{
    public class StorageBO
    {
        public int Storage_number { get; set; }
        public int LocationId { get; set; }
        public string Addres { get; set; }
        public string Phone_number { get; set; }

        public IEnumerable<Product_exmp> Product_Exmps { get; set; } = new List<Product_exmp>();
    }
}
