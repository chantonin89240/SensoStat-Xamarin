using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class SessionDownDto
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("msgAccueil")] public string MsgAccueil { get; set; }

        [JsonProperty("msgFinal")] public string MsgFinal { get; set; }

        [JsonProperty("idPanelist")] public int IdPanelist { get; set; }

        [JsonProperty("instructions")] public List<InstructionDownDto> Instructions { get; set; }

        [JsonProperty("presentations")] public List<PresentationDownDto> Presentations { get; set; }

    }
}
