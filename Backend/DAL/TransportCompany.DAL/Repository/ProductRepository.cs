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
    public class ProductRepository : IProductRepository
    {
        private readonly TransportCompanyContext _context;
        public ProductRepository(TransportCompanyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsListByName(string name)
        {
            var productList = await _context.Products.Where(x => x.Name.Contains(name)).ToListAsync();
            return productList;
        }

        public async Task<IEnumerable<Product_exmp>> GetStorageProducts(int number)
        {
            var productList = await _context.Product_exmps.Where(x => x.Storage_number == number)
                .Include(x => x.Product)
                .ToListAsync();
            return productList;
        }
    }
}
