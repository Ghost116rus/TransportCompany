namespace TransportCompany.DAL.Interfaces
{
    public interface IDistancesRepository
    {
        Task<int> GetTotalLengthBetweenStorages(int sendLocationStorageId, int recieveLocationStarageId);
    }
}
