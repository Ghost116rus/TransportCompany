using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Domain.Entities
{
    public class Distance
    {
        [Required]
        public int StartP { get; set; }

        [Required]
        public int EndP { get; set; }

        [Required]
        public int TotalLength { get; set; }


        [ForeignKey("EndP")]
        public Locations EndPoint { get; set; }
    }
}
