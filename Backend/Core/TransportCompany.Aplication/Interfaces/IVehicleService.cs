using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Requests.Orders;

namespace TransportCompany.Aplication.Interfaces
{
    public interface IVehicleService
    {
        public Task<IEnumerable<VehicleBO>> GetAllVehicle();
        public Task<VehicleBO> GetVehicleByIdNumber(string vehicle_identification_number);
        public Task<IEnumerable<VehicleBO>> GetVehicleForOrder(VehicleForOrder request);
    }
}
