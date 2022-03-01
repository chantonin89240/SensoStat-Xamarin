using System;
using System.Collections.Generic;

namespace SensoStat.Mobile.Models.Entities.Interfaces
{
    public interface ISessionEntity
    {
        int Id { get; set; }

        string Name { get; set; }

        string MsgAccueil { get; set; }

        string MsgFinal { get; set; }

        int IdPanelist { get; set; }
    }
}
