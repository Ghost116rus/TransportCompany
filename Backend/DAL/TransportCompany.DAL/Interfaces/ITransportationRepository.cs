using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Interfaces
{
    public interface ITransportationRepository
    {
        Task<IEnumerable<Transportation>> GetActiveTransportation();
        Task<IEnumerable<Transportation>> GetAllTransportation();
    }
}
