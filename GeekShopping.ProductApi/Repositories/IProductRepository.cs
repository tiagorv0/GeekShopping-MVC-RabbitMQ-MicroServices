using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAllAsync();
        Task<ProductVO> FindByIdAsync(int id);
        Task<ProductVO> CreateAsync(ProductVO vo);
        Task<ProductVO> UpdateAsync(ProductVO vo);
        Task<bool> DeleteAsync(int id);
    }
}
