using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportCompany.Domain.Entities
{
    public class User
    {
        [Key]
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public int TypeOfUser { get; set; }

        public int? ForignKeyToStorage{ get; set; }

        [Column(TypeName = "char(10)")]
        public string? ForignKeyToDriver { get; set; }

        [ForeignKey("ForignKeyToStorage")]
        public Storage Storage { get; set; }

        [ForeignKey("ForignKeyToDriver")]
        public Driver Driver { get; set; }

    }
}
