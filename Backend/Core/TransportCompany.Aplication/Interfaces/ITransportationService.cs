using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Requests.CreateTransportation;
using TransportCompany.Aplication.Responses;

namespace TransportCompany.Aplication.Interfaces
{
    public interface ITransportationService
    {
        Task <BasicResponse> CreateTransportation(RequestToCreateTransportation request);
        Task<IEnumerable<TransportationsBO>> GetActiveTransportations();
        Task<IEnumerable<TransportationsBO>> GetAllTransportations();
    }
}
