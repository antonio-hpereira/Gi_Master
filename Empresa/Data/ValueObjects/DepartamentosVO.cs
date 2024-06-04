namespace GIMaster_Empresa.Data.ValueObjects
{
    public class DepartamentosVO
    {
        public Guid? ID { get; set; }

        public Guid? EmpresaID { get; set; }

        public Guid? Pai { get; set; }

        public Guid? PaiID { get; set; }

        public string? Nome { get; set; }

        public string? Sigla { get; set; }

        public string? UltimaAlteracao { get; set; }

        public string? DataUltimaAlteracao { get; set; }
    }
}
