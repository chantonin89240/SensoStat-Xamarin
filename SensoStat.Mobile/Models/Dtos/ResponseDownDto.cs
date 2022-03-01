using System;
using Newtonsoft.Json;

namespace SensoStat.Mobile.Models.Dtos
{
    public class ResponseDownDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public InstructionDownDto Instruction { get; set; }

        public int IdProduct { get; set; }
    }
}
