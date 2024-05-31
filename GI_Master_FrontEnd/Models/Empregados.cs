using System.ComponentModel.DataAnnotations;


namespace GI_Master_FrontEnd.Models
{
    public class Empregados
    {
        public Guid? ID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }        

        [MinLength(11)]
        [MaxLength(11)]
        [Required(ErrorMessage = "CPF obrigatório")]           
        public string CPF { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Rua { get; set; }

        [Required]
        public string Numero { get; set; }

      
        public string? Status { get; set; }

       
        public string? Foto { get; set; }
    }
}
