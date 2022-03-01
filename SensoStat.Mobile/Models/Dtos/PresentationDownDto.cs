namespace SensoStat.Mobile.Models.Dtos
{
    using System;
    using Newtonsoft.Json;

    public class PresentationDownDto
    {
        [JsonProperty("rank")] public int Rank { get; set; }

        [JsonProperty("idProduct")] public int IdProduct { get; set; }

        [JsonProperty("codeProduit")] public string CodeProduct { get; set; }
    }
}
