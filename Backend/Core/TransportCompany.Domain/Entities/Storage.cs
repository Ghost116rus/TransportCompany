using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TransportCompany.Domain.Entities
{
    [Table("Storage")]
    public class Storage
    {
        [Key]
        [Required]
        public int Storage_number { get; set; }

        [Required]
        [MaxLength(155)]
        public string Addres { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone_number { get; set;}

        [Required]
        [MaxLength(100)]
        public string FIO_manager { get; set; }

        [Required]
        [MaxLength(11)]
        public string Requests { get; set; }


        public IEnumerable<Product_exmp> Product_Exmps { get; set; } = new List<Product_exmp>();

        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
