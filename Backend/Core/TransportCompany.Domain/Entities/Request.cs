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

        
        public int? Num_Sending_storage { get; set; }

        public DateTime? Date_dispatch { get; set; }

        public DateTime? Delivery_date { get; set; }

        public int? Total_time { get; set; }

        public int? Total_length { get; set; }

        public int? Car_load { get; set; }

        [Required]
        public int Total_mass { get; set; }

        [Required]
        public int Total_cost { get; set; }

        public int? Total_shipping_cost { get; set; }



        [Column(TypeName = "char(17)")]
        public string? VehicleID { get; set; }

        [ForeignKey("VehicleID")]
        public Transport_vehicle? vehicle { get; set; }


        [Column(TypeName = "char(10)")]
        public string? DriverID { get; set; }

        [ForeignKey("DriverID")]
        public Driver? Driver { get; set; }


        public IEnumerable<Requare_product> Requare_Products { get; set; } = new List<Requare_product>();

        //public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
