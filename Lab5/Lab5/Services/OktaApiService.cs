using Lab5.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Lab5.Services
{
    public class OktaApiService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public OktaApiService(string apiToken, IConfiguration configuration)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("SSWS", apiToken);
            _configuration = configuration;
        }

        public async Task<AppUser> GetUserAsync(string userId)
        {
            var response = await _httpClient.GetAsync("https://dev-06955424.okta.com/api/v1/users/" + userId);

            string json = await response.Content.ReadAsStringAsync();
            var oktaUser = JsonConvert.DeserializeObject<OktaUser>(json);

            return new AppUser()
            {
                FirstName = oktaUser.Profile.FirstName,
                LastName = oktaUser.Profile.LastName,
                Email = oktaUser.Profile.Email,
                PhoneNumber = oktaUser.Profile.PhoneNumber
            };
        }
    }
}
