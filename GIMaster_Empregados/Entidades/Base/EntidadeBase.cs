using System.ComponentModel.DataAnnotations;

namespace GIMaster_Empregados.Entidades.Base
{
    public class EntidadeBase
    {
        [Key]
        public Guid ID { get; set; }

        public Guid UniqueKey { get; set; }

        public string UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        public string UsuarioExclusao { get; set; }

        public DateTime DataExclusao { get; set; }
    }
}
