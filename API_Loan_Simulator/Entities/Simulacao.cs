namespace API_Loan_Simulator.Entities
{
    public class Simulacao
    {
        public int Id { get; set; }
        public DateTime DataSimulacao { get; set; }
        public decimal ValorEntrada { get; set; }
        public decimal ValorResultado { get; set; }
        public string ParametrosUtilizados { get; set; } // JSON ou string simples
    }
}
