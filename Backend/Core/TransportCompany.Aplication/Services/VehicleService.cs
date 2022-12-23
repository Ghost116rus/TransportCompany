﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
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
                Transported_volume = v.Transported_volume,
                Load_capacity = v.Load_capacity,
                Fuel_consumption = v.Fuel_consumption,
                Required_category = v.Required_category
            });
            return vehicles;
        }
    }
}
