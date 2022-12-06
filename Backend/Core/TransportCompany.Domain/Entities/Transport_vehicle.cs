using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Transport_vehicle")]
    public class Transport_vehicle
    {
        [Key]
        [Required]
        [Column(TypeName = "char(17)")]
        public string Vehicle_identification_number { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [Required]
        [MaxLength(155)]
        public string Location { get; set; }

        [Required]
        [MaxLength(9)]
        public string Status { get; set; }

        [Required]
        public int Transported_volume { get; set;}

        [Required]
        public int Load_capacity { get; set; }

        [Required]
        public float Fuel_consumption { get; set; }

        [Required]
        [MaxLength(13)]
        public string Required_category { get; set; }

        public IEnumerable<Transportation> Transportations { get; set; } = new List<Transportation>();

    }

}
