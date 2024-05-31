namespace GIMaster_Empresa.Data.ValueObjects
{
    public class EmpresaVO
    {
        public Guid? ID { get; set; }
        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string cnpj { get; set; }
        public string? foto { get; set; }
        public string ramo { get; set; }
        public string cnae { get; set; }
        public string DataFundacao { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Status { get; set; }
    }
}
