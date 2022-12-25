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
        Task CancelTransportation(int number);
        Task CreateTransportation(Transportation transportation);
        Task<IEnumerable<Transportation>> GetActiveTransportation();
        Task<IEnumerable<Transportation>> GetAllTransportation();
        Task<Transportation> GetDetailInfoAboutTransportation(int number);
        Task<Transportation> GetDetailTransportationInfoForOperator(int number);
        Task<Transportation> GetDriverByTransportationId(int transportationNumber);

        Task<IEnumerable<Transportation>> GetGetTransportation(int storageNumber);
        Task<IEnumerable<Transportation>> GetSendTransportation(int storageNumber);

        Task SendProducts(int number);
    }
}
