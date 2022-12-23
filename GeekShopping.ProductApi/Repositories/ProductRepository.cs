using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductVO> CreateAsync(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

                if (product is null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> UpdateAsync(ProductVO vo)
        {
            var product = _mapper.Map<Product>(vo);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
