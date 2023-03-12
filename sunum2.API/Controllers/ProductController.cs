using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sunum2.API.Models;
using sunum2.API.Repository.Interfaces;

namespace sunum2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productRepository.GetProducts());
        }

        [HttpGet]
        [Route("GetProductByID/{ID}")]
        public async Task<IActionResult> GetProductByID(int ID)
        {
            return Ok(await _productRepository.GetProductByID(ID));
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productRepository.CreateProduct(product);
            return Ok("Added successfully!");
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
            return Ok("Updated successfully!");
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public JsonResult DeleteProduct(int ID)
        {
            _productRepository.DeleteProduct(ID);
            return new JsonResult(true);
        }
    }
}
