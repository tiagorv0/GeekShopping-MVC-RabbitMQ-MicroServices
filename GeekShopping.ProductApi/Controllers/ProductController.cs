using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repositories;
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
        public async Task<IActionResult> FindByIdAsync(int id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            if(product is null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> FindAllAsync()
        {
            var products = await _productRepository.FindAllAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductVO vo)
        {
            if (vo is null) return BadRequest();

            var created = await _productRepository.CreateAsync(vo);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductVO vo)
        {
            if (vo is null) return BadRequest();

            var updated = await _productRepository.UpdateAsync(vo);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var status = await _productRepository.DeleteAsync(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
