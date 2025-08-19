using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Simulator
{
    public class ResultadoSimulacao
    {
        public int ResultadoSimulacaoId { get; set; }
        public int NumeroParcela { get; set; }
        public decimal ValorAmortizacao { get; set; }
        public decimal ValorJuros { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal SaldoDevedor { get; set; }
    }

}
