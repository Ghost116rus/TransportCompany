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
    public class TransportationRepository : ITransportationRepository
    {
        private readonly TransportCompanyContext _context;

        public TransportationRepository(TransportCompanyContext context)
        {
            _context = context;
        }


        public async Task CreateTransportation(Transportation transportation)
        {
            var requare_products = await _context.Requare_products
                .Where(p => p.RequestID == transportation.RequestNumber).ToListAsync();

            var request = await _context.Requests.Where(r => r.Number == transportation.RequestNumber)
                .FirstOrDefaultAsync();
            if (request == null)
            {
                throw new Exception();
            }
            else
            {
                request.Status = "Обрабатывается";
                _context.Requests.Update(request);
            }
            var driver = await _context.Drivers.Where(d => d.Driver_license_number == transportation.DriverID).FirstOrDefaultAsync();
            if (driver == null)
            {
                throw new Exception();
            }
            else
            {
                driver.Status = "В рейсе";
                _context.Drivers.Update(driver);
            }

            var vehicle = await _context.Transport_vehicles.Where(v => v.Vehicle_identification_number == transportation.VehicleID).FirstOrDefaultAsync();
            if (vehicle == null)
            {
                throw new Exception();
            }
            else
            {
                vehicle.Status = "В рейсе";
                _context.Transport_vehicles.Update(vehicle);
            }

            foreach (var product in requare_products)
            {
                var product_exmp = await _context.Product_exmps.
                    Where(p => p.Сatalogue_number == product.Сatalogue_number && p.Storage_number == transportation.Num_Sending_storage)
                    .FirstOrDefaultAsync();
                if (product_exmp == null)
                {
                    throw new Exception();
                }
                product_exmp.Count = product_exmp.Count - product.Count;

                _context.Product_exmps.Update(product_exmp);
            }        

            _context.Transportations.Add(transportation);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transportation>> GetActiveTransportation()
        {
            var Transportations = await _context.Transportations
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                .Where(r => r.Request.Status == "Обрабатывается" || r.Request.Status == "Доставляется")
                .OrderBy(x => x.Request.DateOfCreate).ToListAsync();
                
            return Transportations;
        }

        public async Task<IEnumerable<Transportation>> GetAllTransportation()
        {
            var Transportations = await _context.Transportations
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                 .OrderByDescending(x => x.Request.DateOfCreate).ToListAsync();

            return Transportations;
        }



        public async Task<Transportation> GetDetailInfoAboutTransportation(int number)
        {
            var transportation = await _context.Transportations
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .Include(t => t.SendingStorage)
                    .ThenInclude(s => s.Location)
                .Include(t => t.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                .FirstOrDefaultAsync(t => t.Number == number);
            return transportation;
        }

        public async Task<Transportation> GetDetailTransportationInfoForOperator(int number)
        {
            var transportation = await _context.Transportations
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .Include(t => t.Request)
                    .ThenInclude(r => r.Requare_Products)
                        .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(t => t.Number == number);
            return transportation;
        }

        public async Task<Transportation> GetDriverByTransportationId(int transportationNumber)
        {
            var transportation = await _context.Transportations
                .Include(t => t.Driver)
                .Where(t => t.Number == transportationNumber)
                .FirstOrDefaultAsync();
            return transportation;
        }

        public async Task<IEnumerable<Transportation>> GetGetTransportation(int storageNumber)
        {
            var Transportations = await _context.Transportations
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                .Where(r => r.Request.Num_Receiving_storage == storageNumber)
                .OrderByDescending(x => x.Request.DateOfCreate).ToListAsync();

            return Transportations;
        }
        public async Task<IEnumerable<Transportation>> GetSendTransportation(int storageNumber)
        {
            var Transportations = await _context.Transportations
                .Where(t => t.Num_Sending_storage == storageNumber)
                .Include(x => x.Driver)
                .Include(x => x.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude(s => s.Location)
                 .OrderByDescending(x => x.Request.DateOfCreate).ToListAsync();

            return Transportations;
        }


        public async Task SendProducts(int number)
        {
            var Transportation = await _context.Transportations
                .Include(t => t.SendingStorage)
                    .ThenInclude(s => s.Location)
                .Include(t => t.Request)
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .FirstOrDefaultAsync(t => t.Number == number);
            if (Transportation == null)
            {
                throw new Exception();
            }

            Transportation.Status = "Товары выданы со склада-отправителя";
            Transportation.Request.Status = "Доставляется";
            Transportation.vehicle.Location = Transportation.SendingStorage.Location.Addres;
            Transportation.Driver.Location = "Получены товары на складе: " + Transportation.SendingStorage.Location.Addres;

            _context.Requests.Update(Transportation.Request);
            _context.Transport_vehicles.Update(Transportation.vehicle);
            _context.Drivers.Update(Transportation.Driver);
            _context.Transportations.Update(Transportation);

            await _context.SaveChangesAsync();
        }

        public async Task CancelTransportation(int number)
        {
            var Transportation = await _context.Transportations
                .Include(t => t.SendingStorage)
                    .ThenInclude(s => s.Location)
                .Include(t => t.Request)
                    .ThenInclude(r => r.Requare_Products)
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .FirstOrDefaultAsync(t => t.Number == number);

            if (Transportation == null)
            {
                throw new Exception();
            }

            Transportation.Status = "Товары отсутсвуют на складе-отправителя";
            Transportation.Request.Status = "Отказано";
            Transportation.vehicle.Status = "Свободен";
            Transportation.Driver.Status = "Свободен";

            _context.Requests.Update(Transportation.Request);
            _context.Transport_vehicles.Update(Transportation.vehicle);
            _context.Drivers.Update(Transportation.Driver);
            _context.Transportations.Update(Transportation);

            foreach (var product in Transportation.Request.Requare_Products)
            {
                var product_exmp = await _context.Product_exmps.
                    Where(p => p.Сatalogue_number == product.Сatalogue_number && p.Storage_number == Transportation.Num_Sending_storage)
                    .FirstOrDefaultAsync();
                if (product_exmp == null)
                {
                    throw new Exception();
                }
                product_exmp.Count = product_exmp.Count + product.Count;

                _context.Product_exmps.Update(product_exmp);
            }

            await _context.SaveChangesAsync();
        }

        public async Task CompleteTransportation(int number)
        {
            var Transportation = await _context.Transportations
                .Include(t => t.Request)
                    .ThenInclude(r => r.RecievingStorage)
                        .ThenInclude( s => s.Location)
                .Include(t => t.Driver)
                .Include(t => t.vehicle)
                .FirstOrDefaultAsync(t => t.Number == number);

            if (Transportation == null)
            {
                throw new Exception();
            }

            Transportation.Status = "Завершена";
            Transportation.Request.Status = "Выполнена";
            Transportation.Request.DateOfComplete = DateTime.Now;
            Transportation.vehicle.Status = "Свободен";
            Transportation.Driver.Status = "Свободен";
            Transportation.vehicle.Location = Transportation.Request.RecievingStorage.Location.Addres;
            Transportation.Driver.Location = Transportation.Request.RecievingStorage.Location.Addres;

            _context.Requests.Update(Transportation.Request);
            _context.Transport_vehicles.Update(Transportation.vehicle);
            _context.Drivers.Update(Transportation.Driver);
            _context.Transportations.Update(Transportation);

            var productList = await _context.Requare_products.Where(p => p.RequestID == Transportation.RequestNumber).ToListAsync();

            foreach (var product in productList)
            {
                var product_exmp = await _context.Product_exmps.
                    Where(p => p.Сatalogue_number == product.Сatalogue_number && p.Storage_number == Transportation.Request.Num_Receiving_storage)
                    .FirstOrDefaultAsync();
                if (product_exmp == null)
                {
                    throw new Exception();
                }
                product_exmp.Count = product_exmp.Count + product.Count;

                _context.Product_exmps.Update(product_exmp);
            }

            await _context.SaveChangesAsync();
        }
    }
}
