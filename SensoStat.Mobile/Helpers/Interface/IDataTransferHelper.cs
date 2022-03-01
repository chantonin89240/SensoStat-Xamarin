using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SensoStat.Mobile.Helpers.Interface
{
    public interface IDataTransferHelper
    {
        Task<TResult> SendAsync<TResult>(string route, HttpMethod method, string jsonContent = null) where TResult : class;
    }
}
