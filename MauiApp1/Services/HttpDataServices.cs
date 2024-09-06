using MauiApp1.Interfase;
using MauiApp1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace testKyzia
{
    public class HttpDataServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _authorizationToken;

        public HttpDataServices(string authorizationToken)
        {
            _httpClient = new HttpClient();
            _authorizationToken = authorizationToken;
        }

        public async Task<IEnumerable<Response>?> GetLocationsAsync(int clientId)
        {
            string url = "http://profsostav.1gb.ru/Locations/GetLocations";

            // Устанавливаем заголовок авторизации
            _httpClient.DefaultRequestHeaders.Add("Authorization", _authorizationToken);

            // Создаем контент для POST-запроса
            var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("clientid", clientId.ToString()) });

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Response>>(responseBody);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
