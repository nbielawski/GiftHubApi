using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using GiftHubMobileNew.Models;
using GiftHubMobileNew.Contracts;
using GiftHub.Models;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace GiftHubMobileNew.Services
{
    internal class GiftsCardService : IGiftCardService
    {
        public static string BearerToken { get; set; }
        private const string _apiUrl = "http://gifthubapi.apphb.com/";

      
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




        public async Task<bool> MakeDonationAsync(GiftCardCreateViewModel card)
        {
            if (string.IsNullOrWhiteSpace(BearerToken)) throw new UnauthorizedAccessException("Bearer token not initialized. Aborting.");

            using (var client = new HttpClient())
            {
                // Build API URL.
                var url = $"{_apiUrl}/api/Card";

                // Construct the request.
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BearerToken);

                // Create the JSON version of the note object. JSON is a string we'll send to the server.
                var json = JsonConvert.SerializeObject(card);

                // Make the call and get the result.
                var result = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json")); // we have to specify we're sending JSON

                // If the call failed, return an empty list.
                return result.IsSuccessStatusCode;

            }

        }




    }
}
