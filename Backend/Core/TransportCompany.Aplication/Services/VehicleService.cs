using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;
using TransportCompany.DAL.Interfaces;


namespace TransportCompany.Aplication.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehicleBO>> GetAllVehicle()
        {
            var vehiclesFromDB = await _vehicleRepository.GetAllVehicle();
            var vehicles = vehiclesFromDB.Select(v => new VehicleBO
            {
                Vehicle_identification_number = v.Vehicle_identification_number,
                Name = v.Name,
                Location = v.Location,
                Status = v.Status,
                //Transported_volume = v.Transported_volume,
                //Load_capacity = v.Load_capacity,
                //Fuel_consumption = v.Fuel_consumption,
                //Required_category = v.Required_category
            });
            return vehicles;
        }

        public async Task<VehicleBO> GetVehicleByIdNumber(string vehicle_identification_number)
        {
            var vehicleFromDB = await _vehicleRepository.GetVehicleByNumber(vehicle_identification_number);
            var vehicle = new VehicleBO()
            {
                Vehicle_identification_number = vehicleFromDB.Vehicle_identification_number,
                Name = vehicleFromDB.Name,
                Location = vehicleFromDB.Location,
                Status = vehicleFromDB.Status,
                Transported_volume = vehicleFromDB.Transported_volume,
                Load_capacity = vehicleFromDB.Load_capacity,
                Fuel_consumption = vehicleFromDB.Fuel_consumption,
                Required_category = vehicleFromDB.Required_category
            };
            return vehicle;
        }
        public async Task<IEnumerable<VehicleBO>> GetVehicleForOrder(VehicleForOrder request)
        {
            var vehiclesFromDB = await _vehicleRepository.GetVehicleForOrder(request.Location, request.TotalVolume, request.TotalMass);
            var vehicleList = vehiclesFromDB.Select(v => new VehicleBO()
            {
                Vehicle_identification_number = v.Vehicle_identification_number,
                Name = v.Name,
                Location = v.Location,
                Transported_volume = v.Transported_volume,
                Load_capacity = v.Load_capacity,
                Fuel_consumption = v.Fuel_consumption,
                Required_category = v.Required_category
            });
            return vehicleList;
        }
    }
}
