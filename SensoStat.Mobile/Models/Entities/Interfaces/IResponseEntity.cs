using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IResponseEntity
    {
        int Id { get; set; }

        string Content { get; set; }

        int IdInstruction { get; set; }

        int IdProduct { get; set; }
    }
}
