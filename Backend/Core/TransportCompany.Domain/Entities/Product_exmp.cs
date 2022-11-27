using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Product_exmp")]
    public class Product_exmp
    {
        [Required]
        public int Storage_number { get; set; }

        [Required]
        [Column(TypeName = "char(35)")]
        public string Сatalogue_number { get; set; }

        [Required]
        public int Count { get; set; }


        [ForeignKey("Storage_number")]
        public Storage Storage { get; set; }

        [ForeignKey("Сatalogue_number")]
        public Product Product { get; set; }
    }
}
