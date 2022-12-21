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
        Task CreateTransportation(Transportation transportation);
        Task<IEnumerable<Transportation>> GetActiveTransportation();
        Task<IEnumerable<Transportation>> GetAllTransportation();
        Task<Transportation> GetDetailInfoAboutTransportation(int number);
        Task<Transportation> GetDriverByTransportationId(int transportationNumber);
    }
}
