using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly ICouponService _couponService;

        public CartController(ICartService cartService, IProductService productService, ICouponService couponService)
        {
            _cartService = cartService;
            _productService = productService;
            _couponService = couponService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await FindUserCart());
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            return View(await FindUserCart());
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartViewModel model)
        {
            var token = await GetToken();

            var response = await _cartService.ApplyCoupon(model, token);

            if (response)
                return RedirectToAction(nameof(CartIndex));

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCoupon()
        {
            var token = await GetToken();
            var userId = GetUserId();

            var response = await _cartService.RemoveCoupon(userId, token);

            if (response)
                return RedirectToAction(nameof(CartIndex));

            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = await GetToken();

            var response = await _cartService.RemoveFromCart(id, token);

            if (response)
                return RedirectToAction(nameof(CartIndex));

            return View();
        }

        private async Task<CartViewModel> FindUserCart()
        {
            var token = await GetToken();
            var userId = GetUserId();

            var response = await _cartService.FindCartByUserId(userId, token);

            if (response?.CartHeader != null)
            {
                if (!string.IsNullOrEmpty(response.CartHeader.CouponCode))
                {
                    var coupon = await _couponService.GetCoupon(response.CartHeader.CouponCode, token);
                    if (coupon?.CouponCode != null)
                        response.CartHeader.DiscountAmount = coupon.DiscountAmount;
                }
                foreach (var detail in response.CartDetails)
                    response.CartHeader.PurchaseAmount += (detail.Product.Price * detail.Count);

                response.CartHeader.PurchaseAmount -= response.CartHeader.DiscountAmount;
            }

            return response;
        }

        private string? GetUserId()
        {
            return User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;
        }

        private async Task<string> GetToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }
}
