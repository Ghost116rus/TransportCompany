﻿
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.DAL.Interfaces;

namespace TransportCompany.Aplication.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public IEnumerable<DriverBO> GetDrivers()
        {
            var driversEntities = _driverRepository.GetDrivers();

            var driverBO = driversEntities.Select(driver => new DriverBO
            {
                Driver_license_number = driver.Driver_license_number,
                FIO = driver.FirstName + " " + driver.SecondName[0] + "." + driver.Patronymic[0] + ".",
                Addres = driver.Addres,
                Phone_number = driver.Phone_number,
                Status = driver.Status,
            });

            return driverBO;
        }
    }
}