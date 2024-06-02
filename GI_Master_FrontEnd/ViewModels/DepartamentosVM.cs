namespace GI_Master_FrontEnd.ViewModels
{
    public class DepartamentosVM
    {
        public Guid ID { get; set; }

        public Guid EmpresaID { get; set; }

        public int Pai { get; set; }

        public int? PaiID { get; set; }

        public string? Nome { get; set; }

        public string? Sigla { get; set; }

        public string? UltimaAlteracao { get; set; }

        public string? DataUltimaAlteracao { get; set; }
    }
}
