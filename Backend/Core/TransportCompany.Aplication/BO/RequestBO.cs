using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Domain.Entities;

namespace TransportCompany.Aplication.BO
{
    public class RequestBO
    {
        public int Number { get; set; }
        public string Status { get; set; }
        public int Num_Receiving_storage { get; set; }
        public int Total_volume { get; set; }
        public int Total_mass { get; set; }
        public int Total_cost { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime? DateOfComplete { get; set; }
        public int TransportationNumber { get; set; }
        public IEnumerable<ProductExmpBO>? productsList { get; set;}

    }
}
