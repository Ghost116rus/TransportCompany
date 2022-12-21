using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportCompany.Aplication.BO;
using TransportCompany.Aplication.Interfaces;
using TransportCompany.DAL.Interfaces;
using TransportCompany.Domain.Entities;

namespace TransportCompany.Aplication.Services
{
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDistancesRepository _distancesRepository;

        public StorageService(IStorageRepository storageRepository, IOrderRepository orderRepository,
            IDistancesRepository distancesRepository)
        {
            _storageRepository = storageRepository;
            _orderRepository = orderRepository;
            _distancesRepository = distancesRepository;
        }

        public async Task<IEnumerable<StorageBO>> GetAllStorages()
        {
            var storages = await _storageRepository.GetAllStorages();
            var StoragesBO = storages.Select(store => new StorageBO
            {
                Storage_number = store.Storage_number,
                Phone_number = store.Phone_number,
                Addres = store.Location.Addres
            });
            return StoragesBO;
        }

        public async Task<StoragesListTransportationBO> GetStoragesRequest(int requestId)
        {
            var storagesNumbers = await _storageRepository.GetStoragesRequest(requestId);

            //Получение номера, получающего склада
            var requestEntity = await _orderRepository.GetOrderByNumber(requestId);
            var recieveNumber = requestEntity.Num_Receiving_storage;

            //Получили принимающий склад
            var recieveStorage = await _storageRepository.GetStorageById(recieveNumber);

            //Получили, отправляющий склады(Пользователь выберет только один)
            List<Storage> senderStorages = new List<Storage>();

            foreach (var id in storagesNumbers)
            {
                senderStorages.Add(await _storageRepository.GetStorageById(id));
            }

            //Формируем бизнес-объект
            StoragesListTransportationBO storagesListTransportation = new StoragesListTransportationBO();

            foreach (var senderStorage in senderStorages)
            {
                var bo = new StoragesTransportationBO
                {
                    StorageId = senderStorage.Storage_number,
                    Address = senderStorage.Location.Addres,
                    TotalLength = await _distancesRepository.GetTotalLengthBetweenStorages(senderStorage.Storage_number, recieveNumber)
                };

                storagesListTransportation.StoragesTransportations.Add(bo);
            }


            return storagesListTransportation;
        }
    }
}
