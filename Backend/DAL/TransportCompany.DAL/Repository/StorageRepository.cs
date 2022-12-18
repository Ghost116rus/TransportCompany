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
    public class StorageRepository : IStorageRepository
    {
        public readonly TransportCompanyContext _context;

        public StorageRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Storage>> GetAllStorages()
        {
            var storages = await _context.Storages
                .Include(x=> x.Location).ToListAsync();
            return storages;
        }


    }
}
