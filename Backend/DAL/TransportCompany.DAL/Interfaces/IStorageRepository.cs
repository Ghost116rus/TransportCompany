using TransportCompany.Domain.Entities;

namespace TransportCompany.DAL.Interfaces
{
    public interface IStorageRepository
    {
        Task<IEnumerable<Storage>> GetAllStorages();

        Task<IEnumerable<int>> GetStoragesRequest(int requestId);

        Task<Storage> GetStorageById(int storageId);
    }
}
