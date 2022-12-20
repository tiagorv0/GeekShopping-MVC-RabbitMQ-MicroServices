using GeekShopping.ProductApi.Data.ValueObjects;

namespace GeekShopping.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> FindAll();
        Task<ProductVO> FindById(int id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(int id);
    }
}
