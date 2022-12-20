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

        public async Task<IEnumerable<Transportation>> GetAllTransportation()
        {
            //var Transportations = await _context.Transportations
            //    .Include(x => x.Driver)
            //    .Include(x => x.Request.Num_Receiving_storage)
            //    .

            //    .ToListAsync();
            //return Transportations;
            return null;
        }
    }
}
