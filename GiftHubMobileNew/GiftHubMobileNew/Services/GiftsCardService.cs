using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using GiftHubMobileNew.Models;

namespace GiftHubMobileNew.Services
{
    internal class GiftsCardService
    {
        public static string BearerToken { get; set; }
        private const string _apiUrl = "http://localhost:50203";

      
        public async Task<bool> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    var url = $"{_apiUrl}/token";

                 
                    var requestString = $"grant_type=password&username={HttpUtility.UrlEncode(username.Trim())}&password={HttpUtility.UrlEncode(password.Trim())}";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "www-form-urlencoded; charset=utf-8");

                   
                    var result = await client.PostAsync(url, new StringContent(requestString));
                    if (!result.IsSuccessStatusCode)
                    {
                        BearerToken = null;
                        return false;
                    }

                    var stringResponseFromServer = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<OauthBearerTokenResponse>(stringResponseFromServer);
                    if (response == null) return false;
                    BearerToken = response.access_token; 
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
