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
        private readonly TransportContext _context;

        public DriverRepository(TransportContext context)
        {
            _context = context;
        }

        public IEnumerable<Driver> GetDrivers()
        {
            var driversEntities = new List<Driver>();
            return driversEntities;
        }
    }
}
