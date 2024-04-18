using APIControleDeProcessos.Interface;
using APIControleDeProcessos.Models;
using APIControleDeProcessos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace APIControleDeProcessos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        {
            _productInterface = productInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetAllProduct()
        {
            var product = await _productInterface.GetAllProducts();
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetProductById(int id)
        {
            var product = _productInterface.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetProductByName(string name)
        {
            var product = await _productInterface.GetProductByName(name);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> CreateProduct(ProductModel newProduct)
        {
            var product = await _productInterface.CreateProduct(newProduct);
            return Ok(product);
        }
    }
}
