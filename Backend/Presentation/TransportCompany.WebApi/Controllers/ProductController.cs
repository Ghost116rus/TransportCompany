using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransportCompany.Aplication.Interfaces;

namespace TransportCompany.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("GetProductsByStorage")]
        public async Task<IActionResult> GetProductsByStorage(int number)
        {
            var products = await _productService.GetProductsForStorage(number);
            return Ok(products);
        }        
        
        [HttpGet("GetProductsByStorageOperator")]
        public async Task<IActionResult> GetProductsByStorageOperator(int number)
        {
            var products = await _productService.GetProductsByStorageOperator(number);
            return Ok(products);
        }

        [HttpGet("GetAllProductsForOrder")]
        public async Task<IActionResult> GetAllProductsForOrder()
        {
            var products = await _productService.GetAllProductsForOrder();
            return Ok(products);
        }

        [HttpGet("GetAllProductsForOrderByName")]
        public async Task<IActionResult> GetAllProductsForOrderByName(string name)
        {
            var products = await _productService.GetProductsListByName(name);
            return Ok(products);
        }
    }
}
