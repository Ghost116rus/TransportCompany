using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Request")]
    public class Request
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number{ get; set; }

        [Required]
        [MaxLength(14)]
        public string Status { get; set; }

        [Required]
        public int Num_Receiving_storage { get; set; }

        [Required]
        public int Total_volume { get; set; }

        [Required]
        public int Total_mass { get; set; }

        [Required]
        public int Total_cost { get; set; }

        [Required]
        public DateTime DateOfCreate { get; set; }
        public DateTime? DateOfComplete { get; set; }

        [ForeignKey("Num_Receiving_storage")]
        public Storage RecievingStorage { get; set; }

        public IEnumerable<Requare_product> Requare_Products { get; set; } = new List<Requare_product>();
        public Transportation transportation { get; set; }
    }
}
