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

        public async Task<Storage> GetStorageById(int storageId)
        {
            return await _context.Storages
                .Include(s => s.Location)
                .FirstOrDefaultAsync(s => s.Storage_number == storageId);
        }

        public async Task<IEnumerable<int>> GetStoragesRequest(int requestId)
        {
            //Получаем заявку
            var requestEntity = await _context
                .Requests
                .Include(r => r.Requare_Products)
                .FirstOrDefaultAsync(r => r.Number == requestId);

            //Если заявка не найдена - ахтунг
            if (requestEntity == null)
                return null;

            //Получаем массив продуктов, которые в заявке
            var requareProducts = requestEntity.Requare_Products.ToArray();

            List<Product_exmp> productExmps = new List<Product_exmp>();
            //List<Storage> storages = new List<Storage>();

            Dictionary<int, List<Product_exmp>> storages = new Dictionary<int, List<Product_exmp>>();

            foreach (var requareProduct in requareProducts)
            {
                var productExemplars = await _context
                .Product_exmps
                .Where(p => p.Сatalogue_number == requareProduct.Сatalogue_number && p.Count >= requareProduct.Count)
                .ToListAsync();

                if (productExemplars == null)
                    continue;

                foreach (var productExemplar in productExemplars)
                {
                    if (!storages.ContainsKey(productExemplar.Storage_number))
                        storages[productExemplar.Storage_number] = new List<Product_exmp>();

                    storages[productExemplar.Storage_number].Add(productExemplar);
                }
                
            }

            List<int> storagesNumbers = new List<int>();

            foreach (var storage in storages)
            {
                if (storage.Value.Count == requareProducts.Length && storage.Key != requestEntity.Num_Receiving_storage)
                    storagesNumbers.Add(storage.Key);
            }

            return storagesNumbers;
        }
    }
}
