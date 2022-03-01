using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient client)
        {
            this._httpClient = client;
        }

        public string GetDataFromHttpClient(string url)
        {
            //call http
            var reponseHttp = _httpClient.GetAsync(url).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }

        public HttpResponseMessage PostDataFromHttpClient(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            //call http
            var reponseHttp = _httpClient.PostAsync(url, stringContent).Result;
            return reponseHttp;
            //lire le resultat => json
            //string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;

        }

        public string PutDataFromHttpClient(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            //call http
            var reponseHttp = _httpClient.PutAsync(url, stringContent).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }

        public string DeleteDataFromHttpClient(string url)
        {
            //call http
            var reponseHttp = _httpClient.DeleteAsync(url).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }

        /// <summary>
        /// Execute une requete Http de type Get Post Put ou Delete suivant le 1er argument "method"
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns>Le body de la réponse http au format string</returns>
        public HttpResponseMessage RequestHttp(HttpMethod method2, string method, string url, object content = null)
        {
            var responseHttp = new HttpResponseMessage();
            var request = new HttpRequestMessage();

            request.Method = method2;
            request.RequestUri = new Uri(url);

            if (method == "Post" || method == "Put")
            {
                var json = JsonConvert.SerializeObject(content);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                switch (method)
                {
                    case "Post":
                        responseHttp = _httpClient.PostAsync(url, stringContent).Result;
                        break;
                    case "Put":
                        responseHttp = _httpClient.PutAsync(url, stringContent).Result;
                        break;
                    default:
                        break;
                }
            }

            switch (method)
            {
                case "Get":
                    responseHttp = _httpClient.GetAsync(url).Result;
                    break;
                case "Delete":
                    responseHttp = _httpClient.DeleteAsync(url).Result;
                    break;
                default:
                    break;
            }

            return responseHttp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseHttp"></param>
        /// <returns></returns>
        public string GetBodyFromHttpMessage(HttpResponseMessage responseHttp)
        {
            return responseHttp.Content.ReadAsStringAsync().Result;
        }
    }
}
