using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Required]
        [Column(TypeName = "char(35)")]
        public string Сatalogue_number { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MaxLength(16)]
        public string Type { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public int Width { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int Cost { get; set; }


        public IEnumerable<Requare_product> Requare_Products { get; set; } = new List<Requare_product>();

        public IEnumerable<Request> Requests { get; set; } = new List<Request>();

        public IEnumerable<Product_exmp> Product_Exmps { get; set; } = new List<Product_exmp>();

        public IEnumerable<Storage> Storages { get; set; } = new List<Storage>();
    }
}
