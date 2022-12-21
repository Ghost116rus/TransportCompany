using Microsoft.EntityFrameworkCore;
using TransportCompany.DAL.Interfaces;

namespace TransportCompany.DAL.Repository
{
    public class DistanceRepository : IDistancesRepository
    {
        private readonly TransportCompanyContext _context;

        public DistanceRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalLengthBetweenStorages(int sendLocationStorageId, int recieveLocationStarageId)
        {
            return (await _context.Distances.Where(d => d.StartP == sendLocationStorageId
            && d.EndP == recieveLocationStarageId).FirstOrDefaultAsync()).TotalLength;
        }
    }
}
