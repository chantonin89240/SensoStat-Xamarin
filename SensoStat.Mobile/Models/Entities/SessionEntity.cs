using System.Collections.Generic;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class SessionEntity : ISessionEntity
    {
        [PrimaryKey] public int Id { get; set; }

        public string Name { get; set; }

        public string MsgAccueil { get; set; }

        public string MsgFinal { get; set; }

        public int IdPanelist { get; set; }

        public SessionEntity()
        {

        }

        public SessionEntity(SessionDownDto session) :this()
        {
            Id = session.Id;
            Name = session.Name;
            MsgAccueil = session.MsgAccueil;
            MsgFinal = session.MsgFinal;
            IdPanelist = session.IdPanelist;
        }
    }
}
