using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SensoStat.Mobile.Helpers.Interface;

namespace SensoStat.Mobile.Helpers
{
    public class DataTransferHelper : IDataTransferHelper
    {
        private HttpClient _httpClient;

        private HttpClient GetClient()
        {
            if (_httpClient == null)
            {
                // uniquement valable en développement
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                    {
                        return true;
                    };
                _httpClient = new HttpClient(handler);
                // _httpClient = new HttpClient();
            }

            return _httpClient;
        }


        public async Task<TResult> SendAsync<TResult>(string route, HttpMethod method, string jsonContent = null) where TResult : class
        {
            try
            {
                var client = GetClient();

                var message = new HttpRequestMessage();

                if (!string.IsNullOrEmpty(jsonContent))
                {
                    message.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                message.Method = method;
                message.RequestUri = new Uri(route);

                var result = await client.SendAsync(message);

                if (!result.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await result.Content.ReadAsStringAsync();
                var resultObj = JsonConvert.DeserializeObject<TResult>(content);
                return resultObj;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
