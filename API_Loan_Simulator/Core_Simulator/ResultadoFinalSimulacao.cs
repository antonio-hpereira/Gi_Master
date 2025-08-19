namespace Core_Simulator
{
    public class ResultadoFinalSimulacao
    {
        public Guid IdSimulacao { get; set; }
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal TaxaJuros { get; set; }
        public List<ResultadoSimulacao> SimulacaoSAC { get; set; }
        public List<ResultadoSimulacao> SimulacaoPRICE { get; set; }

    }
}
