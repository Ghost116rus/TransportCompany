using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Requests.Orders;

namespace TransportCompany.Aplication.Interfaces
{
    public interface IDriverService
    {
        public Task<DriverBO> GetDetailDriverInfo(string Driver_license_number);
        public Task<IEnumerable<DriverBO>> GetDrivers();
        public Task<IEnumerable<DriverForOrderBO>> GetDriversForOrder(DriverForOrder request);
    }
}
