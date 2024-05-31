using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using GIMaster_Empregados.Entidades.Base;

namespace GIMaster_Empregados.Entidades
{
    [Table("tbEmpregado")]
    public class Empregados 
    {
        [Key]
        public Guid? ID { get; set; }        
        public string Nome { get; set; }
        public string CPF { get; set; }                 
        public string DataNascimento { get; set; }              
        public string Email { get; set; }       
        public string Telefone { get; set; }       
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Status { get; set; }
        public string? Foto { get; set; }




    }
}
