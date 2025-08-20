using API_Loan_Simulator.Context;
using API_Loan_Simulator.Core_Simulator.ISimulator;
using API_Loan_Simulator.Entities;
using API_Loan_Simulator.Entities.ViewModel;
using API_Loan_Simulator.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Loan_Simulator.Core_Simulator
{
    public class SimuladorFinanciamento : ISimuladorFinanciamento
    {
        private readonly DBHack_Context _context;
        private readonly MemoryContext _memoryContext;
        private readonly IProdutoRepository _produtoRepository;

        public SimuladorFinanciamento(DBHack_Context context, MemoryContext memoryContext, IProdutoRepository produtoRepository)
        {
            _context = context;
            _memoryContext = memoryContext;
            _produtoRepository = produtoRepository;
        }

        public ResultadoFinalSimulacaoViewModel Simular(DadosSimulacao dados)
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

            var resultado = new ResultadoFinalSimulacaoViewModel
            {
                CO_SIMULACAO_FINAL = Guid.NewGuid(),
                CO_PRODUTO = produto.CO_PRODUTO,
                NO_DESCRICAO_PRODUTO = produto.NO_PRODUTO,
                VR_TAXA_JUROS = produto.PC_TAXA_JUROS,
                SIMULACAO_SAC = CalcularSAC(valorDesejado, prazoMeses, produto.PC_TAXA_JUROS),

            };

            PercisteSimulacoa(resultado, dados);

            return resultado;
        }

        private void PercisteSimulacoa(ResultadoFinalSimulacaoViewModel resultado, DadosSimulacao dados)
        {
            var simulacao = new Simulacao();
            simulacao.CO_SIMULACAO = new Guid();
            simulacao.DT_DATA_SIMULACAO = DateTime.Now;
            simulacao.VR_VALOR_ENTRADA = dados.ValorDesejado;
            simulacao.NU_PARCELAS = dados.Prazo;
            simulacao.Parcelas = new List<Parcelas>();

            foreach (var item in resultado.SIMULACAO_SAC)
            {
                if (item.Parcelas != null)
                {
                    foreach (var parcela in item.Parcelas)
                    {
                        var novaParcela = new Parcelas
                        {
                            NU_NUMERO_PARCELAS = parcela.NU_NUMERO_PARCELAS,
                            VR_VALOR_AMORTIZADO = parcela.VR_VALOR_AMORTIZADO,
                            VR_VALOR_JUROS = parcela.VR_VALOR_JUROS,
                            VR_VALOR_PARCELAS = parcela.VR_VALOR_PARCELAS,
                            VR_SALDO_DEVEDOR = parcela.VR_SALDO_DEVEDOR,

                        };
                        simulacao.Parcelas.Add(novaParcela);
                    }

                }
            }

            _memoryContext.Simulacoes.Add(simulacao);
            _memoryContext.SaveChanges();


        }

        private List<TipoParcelasViewModel> CalcularSAC(decimal valor, int meses, decimal taxaJurosMensal)
        {
            var lista = new List<TipoParcelasViewModel>();
            var ListParcela = new List<ResultadoSimulacaoViewModel>();
            var amortizacao = valor / meses;
            var saldoDevedor = valor;

            for (int i = 1; i <= meses; i++)
            {
                var juros = saldoDevedor * taxaJurosMensal;
                var parcela = amortizacao + juros;

                ListParcela.Add(new ResultadoSimulacaoViewModel
                {
                    NU_NUMERO_PARCELAS = i,
                    VR_VALOR_AMORTIZADO = Math.Round(amortizacao, 2),
                    VR_VALOR_JUROS = Math.Round(juros, 2),
                    VR_VALOR_PARCELAS = Math.Round(parcela, 2),
                    VR_SALDO_DEVEDOR = Math.Round(saldoDevedor - amortizacao, 2)
                });

                saldoDevedor -= amortizacao;
            }
            lista.Add(new TipoParcelasViewModel
            {
                TipoParcela = "SAC",
                Parcelas = ListParcela
            });


            var ListParcelaPrice = new List<ResultadoSimulacaoViewModel>();
            var fator = (decimal)Math.Pow(1 + (double)taxaJurosMensal, meses);
            var parcelaFixa = valor * taxaJurosMensal * fator / (fator - 1);

            for (int i = 1; i <= meses; i++)
            {
                var juros = saldoDevedor * taxaJurosMensal;
                var amortizacaoPrice = parcelaFixa - juros;

                ListParcelaPrice.Add(new ResultadoSimulacaoViewModel
                {
                    NU_NUMERO_PARCELAS = i,
                    VR_VALOR_AMORTIZADO = Math.Round(amortizacaoPrice, 2),
                    VR_VALOR_JUROS = Math.Round(juros, 2),
                    VR_VALOR_PARCELAS = Math.Round(parcelaFixa, 2),
                    VR_SALDO_DEVEDOR = Math.Round(saldoDevedor - amortizacaoPrice, 2)
                });

                saldoDevedor -= amortizacaoPrice;
            }

            lista.Add(new TipoParcelasViewModel
            {
                TipoParcela = "PRICE",
                Parcelas = ListParcela
            });


            return lista;
        }


    }

}
