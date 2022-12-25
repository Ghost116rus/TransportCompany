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
        Task<IEnumerable<TransportationsBO>> GetGetTransportation(int storageNumber);
        Task<IEnumerable<TransportationsBO>> GetSendTransportation(int storageNumber);
        Task<DetailTransportationBO> GetDetailInfoAboutTransportation(int number);
        Task<DetailTransportationForOperatorBO> GetDetailTransportationInfoForOperator(int number);

        Task<BasicResponse> SendProducts(int number);
        Task<BasicResponse> CompleteTransportation(int number);
        Task<BasicResponse> CancelTransportation(int number);

        Task<DetailTransportationBO> GetDetailInfoByLicenseNumber(string license);
        Task<BasicResponse> ChangeStatus(RequestChangeStatusTransportation request);
    }
}
