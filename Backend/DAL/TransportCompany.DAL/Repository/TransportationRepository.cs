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
    public class TransportationRepository : ITransportationRepository
    {
        private readonly TransportCompanyContext _context;

        public TransportationRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task CreateTransportation(Transportation transportation)
        {
            var requare_products = await _context.Requare_products
                .Where(p => p.RequestID == transportation.RequestNumber).ToListAsync();

            var request = await _context.Requests.Where(r => r.Number == transportation.RequestNumber)
                .FirstOrDefaultAsync();
            if (request == null)
            {
                throw new Exception();
            }
            else
            {
                request.Status = "Обрабатывается";
                _context.Requests.Update(request);
            }                          
            foreach (var product in requare_products)
            {
                var product_exmp = await _context.Product_exmps.
                    Where(p => p.Сatalogue_number == product.Сatalogue_number && p.Storage_number == transportation.Num_Sending_storage)
                    .FirstOrDefaultAsync();
                if (product_exmp == null)
                {
                    throw new Exception();
                }
                product_exmp.Count = product_exmp.Count - product.Count;

                _context.Product_exmps.Update(product_exmp);
            }        

            _context.Transportations.Add(transportation);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transportation>> GetActiveTransportation()
        {
            var Transportations = await _context.Transportations
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                .Where(r => r.Request.Status == "Сформирована" || r.Request.Status == "Доставляется")
                .OrderBy(x => x.Request.DateOfCreate).ToListAsync();
                
            return Transportations;
        }

        public async Task<IEnumerable<Transportation>> GetAllTransportation()
        {
            var Transportations = await _context.Transportations
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                 .OrderByDescending(x => x.Request.DateOfCreate).ToListAsync();

            return Transportations;
        }

        public async Task<Transportation> GetDetailInfoAboutTransportation(int number)
        {
            var transportation = await _context.Transportations
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .Include(t => t.SendingStorage)
                    .ThenInclude(s => s.Location)
                .Include(t => t.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                .FirstOrDefaultAsync(t => t.Number == number);
            return transportation;
        }

        public async Task<Transportation> GetDriverByTransportationId(int transportationNumber)
        {
            var transportation = await _context.Transportations
                .Include(t => t.Driver)
                .Where(t => t.Number == transportationNumber)
                .FirstOrDefaultAsync();
            return transportation;
        }
    }
}
