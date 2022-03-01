using System;
using Newtonsoft.Json;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.Dtos
{
    public class InstructionDownDto : IInstructionEntity
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("libelle")] public string Libelle { get; set; }

        [JsonProperty("chronology")] public int Chronology { get; set; }

        [JsonProperty("isQuestion")] public bool IsQuestion { get; set; }
        
    }
}
