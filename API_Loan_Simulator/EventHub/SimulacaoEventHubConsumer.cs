using Azure.Messaging.EventHubs;
using global::Core_Simulator;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Text;
using System.Text.Json;

namespace API_Loan_Simulator.EventHub
{

    public static class SimulacaoEventHubConsumer
    {
        [FunctionName("ProcessarSimulacao")]
        public static async Task Run(
            [EventHubTrigger("simulacoes-financiamento", Connection = "EventHubConnectionAppSetting")] EventData[] eventos,
            ILogger log)
        {
            foreach (var evento in eventos)
            {
                try
                {
                    var json = Encoding.UTF8.GetString(evento.EventBody.ToArray());
                    var simulacao = JsonSerializer.Deserialize<ResultadoFinalSimulacao>(json);

                    log.LogInformation($"Simulação recebida: Produto {simulacao.CodigoProduto}, Juros {simulacao.TaxaJuros}");

                    // Aqui você pode salvar no banco, enviar para outro serviço, etc.
                    await ProcessarSimulacao(simulacao, log);
                }
                catch (Exception ex)
                {
                    log.LogError($"Erro ao processar evento: {ex.Message}");
                }
            }
        }

        private static Task ProcessarSimulacao(ResultadoFinalSimulacao simulacao, ILogger log)
        {
            // Exemplo: salvar em banco, enviar para fila, etc.
            log.LogInformation($"Processando simulação {simulacao.IdSimulacao} com {simulacao.SimulacaoSAC.Count} parcelas SAC.");
            return Task.CompletedTask;
        }
    }

}
