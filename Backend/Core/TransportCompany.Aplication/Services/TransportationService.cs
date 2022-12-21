using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.DAL.Interfaces;


namespace TransportCompany.Aplication.Services
{
    public class TransportationService : ITransportationService
    {
        private readonly ITransportationRepository transportationRepository;

        public TransportationService(ITransportationRepository transportationRepository)
        {
            this.transportationRepository = transportationRepository;
        }

        public async Task<IEnumerable<TransportationsBO>> GetActiveTransportations()
        {
            var transpFromDb = await transportationRepository.GetActiveTransportation();

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }

        public async Task<IEnumerable<TransportationsBO>> GetAllTransportations()
        {
            var transpFromDb = await transportationRepository.GetAllTransportation();

            if (transpFromDb == null)
            {
                return null;
            }

            var transportations = transpFromDb.Select(t => new TransportationsBO
            {
                Number = t.Number,
                Status = t.Status,
                Date_dispatch = t.Date_dispatch,
                Delivery_date = t.Delivery_date,
                DeliveryAddres = t.Request.RecievingStorage.Location.Addres,
                FullName = t.Driver.FirstName + " " + t.Driver.SecondName[0] + ". " + t.Driver.Patronymic[0] + ".",
                RequestNumber = t.RequestNumber
            });

            return transportations;
        }
    }
}
