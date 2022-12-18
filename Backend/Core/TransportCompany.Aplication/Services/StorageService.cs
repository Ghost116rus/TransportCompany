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
    public class StorageService : IStorageService
    {
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
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
    }
}
