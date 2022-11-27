using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Requare_product")]
    public class Requare_product
    {

        [Required]
        public int RequestID { get; set; }

        [Required]
        [Column(TypeName = "char(35)")]
        public string Сatalogue_number { get; set; }

        [Required]
        public int Count { get; set; }



        [ForeignKey("RequestID")]
        public Request Request { get; set; }

        [ForeignKey("Сatalogue_number")]
        public Product Product { get; set; }
    }
}
