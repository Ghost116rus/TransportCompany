
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.Aplication.Requests.Orders;
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

        public async Task<DriverBO> GetDetailDriverInfo(string Driver_license_number)
        {
            var driverFromDB = await _driverRepository.GetDetailDriverInfo(Driver_license_number);
            var driver = new DriverBO()
            {
                Driver_license_number = Driver_license_number,
                FIO = driverFromDB.FirstName + " " + driverFromDB.SecondName[0] + "." + driverFromDB.Patronymic[0] + ".",
                Addres = driverFromDB.Addres,
                Phone_number = driverFromDB.Phone_number,
                Driver_license_category = driverFromDB.Driver_license_category,
                Expirience = GetExpirience(driverFromDB.Year_of_start_work),
                Location = driverFromDB.Location,
                Status = driverFromDB.Status,
                Transportations = driverFromDB.Transportations.Select(x => new TransportationsBO
                {
                    Number = x.Number,
                    RequestNumber = x.RequestNumber,
                    Status = x.Status,
                    Date_dispatch = x.Date_dispatch,
                    DeliveryAddres = x.Request.RecievingStorage.Location.Addres
                })
            };
            return driver;
        }

        private string GetExpirience(string year_of_start_work)
        {
            int yearNow = DateTime.Now.Year - int.Parse(year_of_start_work);
            return yearNow.ToString();
        }

        public async Task<IEnumerable<DriverBO>> GetDrivers()
        {
            var driversEntities = await _driverRepository.GetDrivers();

            if (driversEntities == null)
            {
                return null;
            }

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

        public async Task<IEnumerable<DriverForOrderBO>> GetDriversForOrder(DriverForOrder request)
        {
            var driversFromDB = await _driverRepository.GetDriversForOrder(request.Location, request.RequareCategory);
            var drivers = driversFromDB.Select(driver => new DriverForOrderBO()
            {
                Driver_license_number = driver.Driver_license_number,
                Fullname = driver.FirstName + " " + driver.SecondName[0] + "." + driver.Patronymic[0] + ".",
                Expirience = int.Parse(GetExpirience(driver.Year_of_start_work)),
                CountOfTransportation = driver.Transportations.Count()
            });

            return drivers;
        }
    }
}
