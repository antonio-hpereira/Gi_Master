using System;
using System.ComponentModel.DataAnnotations;

namespace GiMaster_EntidadeBase
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
