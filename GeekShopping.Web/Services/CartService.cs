using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class CartService : BaseService, ICartService
    {
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client) : base(client) { }

        public async Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            SendTokenToHeader(token);
            var response = await _client.PostAsJson($"{BasePath}/add-cart", cart);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            SendTokenToHeader(token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentAs<CartViewModel>();
        }

        public Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveFromCart(int id, string token)
        {
            SendTokenToHeader(token);
            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            SendTokenToHeader(token);
            var response = await _client.PutAsJson($"{BasePath}/update-cart", cart);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CartViewModel>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
