using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TransportCompany.Domain.Entities
{
    [Table("Storage")]
    public class Storage
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Storage_number { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Locations Location { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone_number { get; set;}

        public IEnumerable<Product_exmp> Product_Exmps { get; set; } = new List<Product_exmp>();
    }
}
