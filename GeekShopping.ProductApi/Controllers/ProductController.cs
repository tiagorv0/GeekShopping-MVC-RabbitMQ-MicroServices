using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            var product = await _productRepository.FindById(id);
            if(product is null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var products = await _productRepository.FindAll();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVO vo)
        {
            if (vo is null) return BadRequest();

            var created = await _productRepository.Create(vo);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductVO vo)
        {
            if (vo is null) return BadRequest();

            var updated = await _productRepository.Update(vo);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _productRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
