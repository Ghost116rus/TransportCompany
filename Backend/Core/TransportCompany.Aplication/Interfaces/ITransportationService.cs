﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;

namespace TransportCompany.Aplication.Interfaces
{
    public interface ITransportationService
    {
        Task<IEnumerable<TransportationBO>> GetAllTransportations();
    }
}
