using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ResponseDownDto
    {
        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("idInstruction")] public int IdInstruction { get; set; }

        [JsonProperty("idPanelist")] public int IdPaneliste { get; set; }

        [JsonProperty("idProduct")] public int IdProduct { get; set; }

        [JsonProperty("commentResponse")] public string CommentResponse { get; set; }

    }
}
