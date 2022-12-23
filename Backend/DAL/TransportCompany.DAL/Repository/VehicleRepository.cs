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
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TransportCompanyContext _context;

        public VehicleRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transport_vehicle>> GetAllVehicle()
        {
            var vehicles = await _context.Transport_vehicles.ToListAsync();
            return vehicles; 
        }

        public async Task<Transport_vehicle> GetVehicleByNumber(string vehicle_identification_number)
        {
            var vehicle = await _context.Transport_vehicles.FirstOrDefaultAsync(vehicle => vehicle.Vehicle_identification_number == vehicle_identification_number);
            return vehicle;
        }
    }
}
