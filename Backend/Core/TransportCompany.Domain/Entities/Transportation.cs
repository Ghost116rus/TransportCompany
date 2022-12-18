using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Domain.Entities
{
    public class Transportation
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Number { get; set; }

        public int Num_Sending_storage { get; set; }

        public DateTime Date_dispatch { get; set; }

        public DateTime Delivery_date { get; set; }

        public int Total_length { get; set; }

        public int Car_load { get; set; }

        public int Total_shipping_cost { get; set; }

        [Required]
        [MaxLength(255)]
        public string Status { get; set; }


        public int RequestNumber { get; set; }

        [ForeignKey("RequestNumber")]
        public Request Request { get; set; }


        [Column(TypeName = "char(17)")]
        public string VehicleID { get; set; }

        [ForeignKey("VehicleID")]
        public Transport_vehicle vehicle { get; set; }


        [Column(TypeName = "char(10)")]
        public string DriverID { get; set; }

        [ForeignKey("DriverID")]
        public Driver Driver { get; set; }
    }
}
