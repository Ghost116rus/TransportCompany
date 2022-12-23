using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Transport_vehicle>> GetAllVehicle();
    }
}
