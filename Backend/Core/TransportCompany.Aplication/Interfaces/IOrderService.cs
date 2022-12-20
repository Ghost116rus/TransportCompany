using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Requests.Orders;
using TransportCompany.Aplication.Responses;
using TransportCompany.Domain.Entities;


namespace TransportCompany.Aplication.Interfaces
{
    public interface IOrderService
    {
        Task<RequestBO> GetOrderByNumber(int number);
        Task<IEnumerable<RequestBO>> GetAllOrders();
        Task<IEnumerable<RequestBO>> GetAllPandingOrder();

        Task<BasicResponse> CreateOrder(NewOrder newOrder);
    }
}
