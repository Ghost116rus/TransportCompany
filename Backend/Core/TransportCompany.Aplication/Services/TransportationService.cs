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

        public async Task<IEnumerable<TransportationBO>> GetAllTransportations()
        {
            var transpFromDb = await transportationRepository.GetAllTransportation();

            var transportations = transpFromDb.Select(x => new TransportationBO
            {

            })

        }
    }
}
