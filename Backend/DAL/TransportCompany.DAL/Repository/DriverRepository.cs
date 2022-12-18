using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly TransportCompanyContext _context;

        public DriverRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            var driversEntities = _context.Drivers.ToList();
            return driversEntities;
        }
    }
}
