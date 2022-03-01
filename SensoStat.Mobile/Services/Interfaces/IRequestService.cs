using System;
using System.Threading.Tasks;
using SensoStat.Mobile.Models.Dtos;

namespace SensoStat.Mobile.Services.Interfaces
{
    public interface IRequestService
    {

        Task<SessionDownDto> GetSession();
    }
}
