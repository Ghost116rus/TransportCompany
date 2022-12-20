using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TransportCompanyContext _context;

        public OrderRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<Request> GetOrderByNumber(int number)
        {
            var order = await _context.Requests
                .Include(x => x.Requare_Products)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Number == number);

            return order;
        }


        public async Task<IEnumerable<Request>> GetAllOrder()
        {
            var orders = await _context.Requests.OrderBy(x => x.DateOfCreate).ToListAsync();
            return orders;
        }


        public async Task<IEnumerable<Request>> GetPandingOrder()
        {
            var pandingOrders = await _context.Requests.
                Where(x => x.Status == "Сформирована")
                .OrderBy(x => x.DateOfCreate)
                .ToListAsync();

            return pandingOrders;
        }
    }
}
