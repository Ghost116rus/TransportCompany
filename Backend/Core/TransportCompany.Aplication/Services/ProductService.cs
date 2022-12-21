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

            if (products == null)
            {
                return null;
            }

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

        public async Task<IEnumerable<ProductOperatorBO>> GetAllProductsForOrder()
        {
            var products = await _productRepository.GetAllProducts();

            if (products == null)
            {
                return null;
            }

            var productsBO = products.Select(product => new ProductOperatorBO
            {
                Сatalogue_number = product.Сatalogue_number,
                Name = product.Name,
                Type = product.Type,
                Volume = ( product.Length * product.Width * product.Width) / 1_000_000,
                Weight = product.Weight,
                Cost = product.Cost
            });
            return productsBO;

        }

        public async Task<IEnumerable<ProductListOperator>> GetProductsByStorageOperator(int number)
        {
            var productList = await _productRepository.GetStorageProducts(number);

            if (productList == null)
            {
                return null;
            }

            var products = productList.Select(product => new ProductListOperator
            {
                Сatalogue_number = product.Сatalogue_number,
                Name = product.Product.Name,
                Count = product.Count,
                Type = product.Product.Type,
                Cost = product.Product.Cost                
            });

            return products;
        }

        public async Task<IEnumerable<ProductExmpBO>> GetProductsForStorage(int number)
        {
            var productList = await _productRepository.GetStorageProducts(number);

            if (productList == null)
            {
                return null;
            }

            var products = productList.Select(product => new ProductExmpBO
            {
                Сatalogue_number = product.Сatalogue_number,
                Name = product.Product.Name,
                Count = product.Count,
            });

            return products;
        }

        public async Task<IEnumerable<ProductOperatorBO>> GetProductsListByName(string Name)
        {
            var productList = await _productRepository.GetProductsListByName(Name);

            if (productList == null)
            {
                return null;
            }

            var productsBO = productList.Select(product => new ProductOperatorBO
            {
                Сatalogue_number = product.Сatalogue_number,
                Name = product.Name,
                Type = product.Type,
                Volume = (product.Length * product.Width * product.Width) / 1_000_000,
                Weight = product.Weight,
                Cost = product.Cost
            });

            return productsBO;
        }
    }
}
