using System;
using SensoStat.Mobile.Models.Entities.Interfaces;

namespace SensoStat.Mobile.Models.EntitiesWrapper
{
    public class InstructionEntityWrapper : IInstructionEntity, IPresentationEntity
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int Chronology { get; set; }
        public bool IsQuestion { get; set; }

        public int Rank { get; set; }
        public int IdProduct { get ; set ; }
        public string CodeProduct { get ; set ; }

        public string FormatText => $"{Libelle} {CodeProduct}";

        public string GetPosition()
        {
            return Chronology.ToString();
        }

        public string DynamicFormatText { get => $"{Libelle} {CodeProduct}"; }
        

        public InstructionEntityWrapper()
        {
        }

        public InstructionEntityWrapper(IInstructionEntity instruction, IPresentationEntity presentation) : this()
        {
            Id = instruction.Id;
            Libelle = instruction.Libelle;
            Chronology = instruction.Chronology;
            IsQuestion = instruction.IsQuestion;

            Rank = presentation.Rank;
            IdProduct = presentation.IdProduct;
            CodeProduct = presentation.CodeProduct;
        }
    }
}
