using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GiMaster_Empregado.Data.ValueObjects
{
    public class EmpregadoVO
    {
       
        public Guid ID { get; set; }

        public Guid UniqueKey { get; set; }

        public string CPF { get; set; }
        
        public string Nome { get; set; }
       
        public string DataNascimento { get; set; }
       
        public string Email { get; set; }
       
        public string Status { get; set; }       

        public string UsuarioInclusao { get; set; }

        public DateTime DataInclusao { get; set; }

        public string UsuarioExclusao { get; set; }

        public DateTime DataExclusao { get; set; }

       


    }
}
