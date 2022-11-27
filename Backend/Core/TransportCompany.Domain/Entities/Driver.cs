using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportCompany.Domain.Entities
{
    [Table("Driver")]
    public class Driver
    {
        [Key]
        [Required]
        [Column(TypeName = "char(10)")]
        public string Driver_license_number { get; set; }

        [Required]
        [MaxLength(100)]
        public string FIO { get; set; }

        [Required]
        [MaxLength(155)]
        public string Addres { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone_number { get; set; }

        [Required]
        [MaxLength(13)]
        public string Driver_license_category { get; set; }

        [Required]
        [Column(TypeName = "char(4)")]
        public string Year_of_start_work { get; set; }

        [Required]
        [MaxLength(155)]
        public string Location { get; set; }

        [Required]
        [MaxLength(13)]
        public string Status { get; set; }

        public IEnumerable<Request> Requests { get; set; } = new List<Request>();   
    }
}
