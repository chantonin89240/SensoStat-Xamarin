using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IPresentationEntity
    {
        int Rank { get; set; }

        string CodeProduct { get; set; }

        int IdProduct { get; set; }
    }
}
