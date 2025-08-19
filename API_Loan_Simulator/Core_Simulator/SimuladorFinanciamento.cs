using API_Loan_Simulator.Context;
using API_Loan_Simulator.Core_Simulator;
using API_Loan_Simulator.Core_Simulator.ISimulator;
using API_Loan_Simulator.Entities;
using API_Loan_Simulator.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Simulator
{
    public class SimuladorFinanciamento : ISimuladorFinanciamento
    {
        DBHack_Context _context;
        private readonly IProdutoRepository _produtoRepository;
        public SimuladorFinanciamento(DBHack_Context context, IProdutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = produtoRepository;
        }


        public ResultadoFinalSimulacao Simular(DadosSimulacao dados)
        {
            decimal valorDesejado = dados.ValorDesejado;
            int prazoMeses = dados.Prazo;

            if (valorDesejado <= 0)
                throw new ArgumentException("Valor desejado deve ser maior que zero.");
            if (prazoMeses <= 0)
                throw new ArgumentException("Prazo em meses deve ser maior que zero.");
            if (prazoMeses > 120)
                throw new ArgumentException("Prazo em meses não pode ser maior que 120 meses.");

            var produto = _produtoRepository.ObterProdutoParaSimulacaoAsync(valorDesejado, prazoMeses).Result;

            var resultado = new ResultadoFinalSimulacao
            {
                IdSimulacao = Guid.NewGuid(),
                CodigoProduto = produto.CO_PRODUTO,
                DescricaoProduto = produto.NO_PRODUTO,
                TaxaJuros = produto.PC_TAXA_JUROS,
                SimulacaoSAC = CalcularSAC(valorDesejado, prazoMeses, produto.PC_TAXA_JUROS),
                SimulacaoPRICE = CalcularPRICE(valorDesejado, prazoMeses, produto.PC_TAXA_JUROS)
            };



            return resultado;
        }

        private void PercisteSimulacoa(ResultadoFinalSimulacao resultado)
        {


        }

        private List<ResultadoSimulacao> CalcularSAC(decimal valor, int meses, decimal taxaJurosMensal)
        {
            var lista = new List<ResultadoSimulacao>();
            var amortizacao = valor / meses;
            var saldoDevedor = valor;

            for (int i = 1; i <= meses; i++)
            {
                var juros = saldoDevedor * taxaJurosMensal;
                var parcela = amortizacao + juros;

                lista.Add(new ResultadoSimulacao
                {
                    NumeroParcela = i,
                    ValorAmortizacao = Math.Round(amortizacao, 2),
                    ValorJuros = Math.Round(juros, 2),
                    ValorParcela = Math.Round(parcela, 2),
                    SaldoDevedor = Math.Round(saldoDevedor - amortizacao, 2)
                });

                saldoDevedor -= amortizacao;
            }

            return lista;
        }

        private List<ResultadoSimulacao> CalcularPRICE(decimal valor, int meses, decimal taxaJurosMensal)
        {
            var lista = new List<ResultadoSimulacao>();
            var saldoDevedor = valor;

            var fator = (decimal)(Math.Pow(1 + (double)taxaJurosMensal, meses));
            var parcelaFixa = valor * taxaJurosMensal * fator / (fator - 1);

            for (int i = 1; i <= meses; i++)
            {
                var juros = saldoDevedor * taxaJurosMensal;
                var amortizacao = parcelaFixa - juros;

                lista.Add(new ResultadoSimulacao
                {
                    NumeroParcela = i,
                    ValorAmortizacao = Math.Round(amortizacao, 2),
                    ValorJuros = Math.Round(juros, 2),
                    ValorParcela = Math.Round(parcelaFixa, 2),
                    SaldoDevedor = Math.Round(saldoDevedor - amortizacao, 2)
                });

                saldoDevedor -= amortizacao;
            }

            return lista;
        }
    }

}
