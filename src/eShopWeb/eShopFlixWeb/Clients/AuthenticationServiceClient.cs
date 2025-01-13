using eShopFlixWeb.Models;
using System.Text;
using Newtonsoft.Json;

namespace eShopFlixWeb.Clients
{
    public class AuthenticationServiceClient
    {
        private readonly HttpClient httpClient;

        public AuthenticationServiceClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<User> LoginAsync(LoginModel model)
        {
            StringContent content = new StringContent(content: JsonConvert.SerializeObject(model),
                encoding: Encoding.UTF8, mediaType: "application/json");

            using var response = await httpClient.PostAsync("auth/login", content);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(data)!;
            }

            return new User();
        }

        public async Task<bool> RegisterUserAsync(SignUpModel model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), encoding: Encoding.UTF8,
                mediaType: "application/json");

            using var response = await httpClient.PostAsync("auth/signup", content);

            if(response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
