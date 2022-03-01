using System;
namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface IInstructionEntity
    {
        int Id { get; set; }

        string Libelle { get; set; }

        int Chronology { get; set; }

        bool IsQuestion { get; set; }
    }
}
