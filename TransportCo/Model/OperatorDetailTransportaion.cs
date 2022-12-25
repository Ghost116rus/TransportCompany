﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCo.DTO;

namespace TransportCo.Model
{
    public class OperatorDetailTransportaion
    {
        public int Number { get; set; }
        public int Num_Sending_storage { get; set; }
        public string Status { get; set; }
        public DateTime Date_dispatch { get; set; }


        public string Vehicle_identification_number { get; set; }
        public string Name { get; set; }

        public string fullName { get; set; }
        public string phoneNumber { get; set; }

        public List<ProductForListDTO> ProductsList { get; set; } = null;
    }
}
