using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net;

namespace GeekShopping.Web.Services
{
    public class CouponService : BaseService, ICouponService
    {
        public const string BasePath = "api/v1/coupon";

        public CouponService(HttpClient client) : base(client) {}

        public async Task<CouponViewModel> GetCoupon(string code, string token)
        {
            SendTokenToHeader(token);
            var response = await _client.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
            return await response.ReadContentAs<CouponViewModel>();
        }
    }
}
