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
                .Include(x => x.transportation)
                    .ThenInclude(t => t.Driver)
                .Include(x => x.RecievingStorage)
                    .ThenInclude(s => s.Location)
                .Include(x => x.Requare_Products)
                    .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.Number == number);

            return order;
        }


        public async Task<IEnumerable<Request>> GetAllOrder()
        {
            var orders = await _context.Requests
                .Include(x => x.RecievingStorage)
                    .ThenInclude(s => s.Location)
                .OrderByDescending(x => x.DateOfCreate).ToListAsync();
            return orders;
        }


        public async Task<IEnumerable<Request>> GetPandingOrder()
        {
            var pandingOrders = await _context.Requests.
                Where(x => x.Status == "Сформирована" || x.Status == "Обрабатывается")
                .Include(x => x.RecievingStorage)
                    .ThenInclude(s => s.Location)
                .OrderBy(x => x.DateOfCreate)
                .ToListAsync();

            return pandingOrders;
        }

        public async Task<int> CreateOrder(Request order)
        {
            _context.Requests.Add(order);
            await _context.SaveChangesAsync();
            return order.Number;
        }

        public async Task CreateOrderList(Requare_product product)
        {
            _context.Requare_products.Add(product);
            await _context.SaveChangesAsync();
            return;
        }

        public async Task CancelOrder(int number)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Number == number);
            request.Status = "Отказано";
            _context.Requests.Update(request);

            await _context.SaveChangesAsync();

            return;
        }

        public async Task<IEnumerable<Request>> GetAllOrderByStorageNumber(int number)
        {
            var orders = await _context.Requests
                .Include(x => x.RecievingStorage)
                    .ThenInclude(s => s.Location)
                .Where(x => x.Num_Receiving_storage == number)
                .OrderByDescending(x => x.DateOfCreate).ToListAsync();
            return orders;
        }
    }
}
