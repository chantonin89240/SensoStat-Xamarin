using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Helpers.Interface;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.Mobile.Services
{
    public class RequestService : IRequestService
    {
        private readonly IDataTransferHelper _dataTransferHelper;

        private readonly HttpClientService _clientService;

        public RequestService(IDataTransferHelper dataTransferHelper, HttpClientService clientService)
        {
            _dataTransferHelper = dataTransferHelper;
            _clientService = clientService;
        }

        public async Task<SessionDownDto> GetSession()
        {
            try
            {
                var route = $"{Constants.BaseServerAddress}{Constants.RandomEndpoint}";
                // var result2 = _clientService.GetDataFromHttpClient("https://localhost:5001/api/Pwa?hash=H9UOcgfQWdmUZxrco804UKqSftKCEgE4FeU5QMbOJnw%3D");

                var result = await _dataTransferHelper.SendAsync<SessionDownDto>(route, HttpMethod.Get);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<ResponseDownDto> PostReponse(ResponseDownDto response)
        {
            try
            {
                var json = JsonConvert.SerializeObject(response);

                var route = $"{Constants.BaseServerAddress}{Constants.PostResponse}";

                var result = await _dataTransferHelper.SendAsync<ResponseDownDto>(route, HttpMethod.Post, json);

                return result;
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
