using System;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Models.Entities.Interfaces;
using SQLite;

namespace SensoStat.Mobile.Models.Entities
{
    public class PresentationEntity : IPresentationEntity
    {
        public int Rank { get; set; }

        //[PrimaryKey]
        public string CodeProduct { get; set; }

        //[PrimaryKey]
        public int IdProduct { get; set; }

        public PresentationEntity()
        {
        }

        public PresentationEntity(PresentationDownDto presentation) : this()
        {
            Rank = presentation.Rank;
            CodeProduct = presentation.CodeProduct;
            IdProduct = presentation.IdProduct;
        }
    }
}
