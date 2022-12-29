using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public abstract class BaseService
    {
        protected readonly HttpClient _client;

        public BaseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));

        }

        protected void SendTokenToHeader(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
