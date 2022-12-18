using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompany.Domain.Entities
{
    public class Locations
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(155)]
        public string Addres { get; set; }

        public IEnumerable<Storage> Storages { get; set; } = new List<Storage>();
    }
}
