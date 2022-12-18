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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductBO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();
            var productsBO = products.Select(product => new ProductBO
            {
                Сatalogue_number = product.Сatalogue_number,
                Name = product.Name,
                Type = product.Type,
                Length = product.Length,
                Width = product.Width,
                Height = product.Height,
                Weight = product.Weight,
                Cost = product.Cost
            });
            return productsBO;
        }
    }
}
