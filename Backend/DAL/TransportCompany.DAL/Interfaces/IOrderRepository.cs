using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Domain.Entities;


namespace TransportCompany.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<Request> GetOrderByNumber(int number);
        Task<IEnumerable<Request>> GetAllOrder();
        Task<IEnumerable<Request>> GetPandingOrder();
        Task<int> CreateOrder(Request order);
        Task CreateOrderList(Requare_product product);
        Task CancelOrder(int number);
        Task<IEnumerable<Request>> GetAllOrderByStorageNumber(int number);
    }
}
