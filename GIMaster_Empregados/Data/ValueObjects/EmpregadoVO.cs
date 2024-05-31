namespace GIMaster_Empregados.Data.ValueObjects
{
    public class EmpregadoVO
    {
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
