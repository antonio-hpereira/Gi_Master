using GiMaster_Empregado.Entidades.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GiMaster_Empregado.Entidades
{
    [Table("tbEmpregado")]
    public class Empregados : EntidadeBase
    {

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "CPF obrigatório")]       
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o e-mail do empregado")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe um e-mail válido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        public string Status { get; set; }


    }
}
