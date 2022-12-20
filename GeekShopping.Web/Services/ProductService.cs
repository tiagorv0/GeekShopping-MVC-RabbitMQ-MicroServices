using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
            
        }

        public Task<ProductModel> CreateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            return await _client.
        }

        public Task<ProductModel> FindProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
