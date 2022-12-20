using Microsoft.EntityFrameworkCore;
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

        public async Task<Driver> GetDetailDriverInfo(string Driver_license_number)
        {
            var driver = await _context.Drivers
                .Include(x => x.Transportations)
                    .ThenInclude(x => x.Request)
                        .ThenInclude(x => x.RecievingStorage)
                            .ThenInclude(y => y.Location)
                .FirstOrDefaultAsync(driver => driver.Driver_license_number == Driver_license_number);
            return driver;
        }

        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            var driversEntities = await _context.Drivers.ToListAsync();
            return driversEntities;
        }
    }
}
