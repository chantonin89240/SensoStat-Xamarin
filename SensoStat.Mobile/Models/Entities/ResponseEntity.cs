namespace SensoStat.Mobile.Models.Entities
{
    using SensoStat.Mobile.Models.Dtos;
    using SensoStat.Mobile.Models.Entities.Interfaces;
    using SQLite;

    public class ResponseEntity : IResponseEntity
    {
        [PrimaryKey] [AutoIncrement] public int Id { get ; set ; }

        public string Content { get ; set ; }

        public int IdInstruction { get ; set ; }

        public int IdProduct { get; set; }

        public int IdPanelist { get; set; }

        public ResponseEntity()
        {
        }
    }
}
