
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using global::Core_Simulator;
using System.Text;
using System.Text.Json;
using Azure.Messaging.EventHubs.Producer;


namespace API_Loan_Simulator.EventHub
{

    public class EventHubSimulacaoPublisher
    {
        private readonly string _connectionString;
        private readonly string _eventHubName;
        private readonly EventHubProducerClient _producerClient;
        private readonly ILogger<EventHubSimulacaoPublisher> _logger;
        public EventHubSimulacaoPublisher(string connectionString, string eventHubName, ILogger<EventHubSimulacaoPublisher> logger)
        {
            _connectionString = connectionString;
            _eventHubName = eventHubName;
            _logger = logger;

            _producerClient = new EventHubProducerClient(_connectionString, _eventHubName);
        }


        public async void TesteConexao()
        {            
            var producer = new EventHubProducerClient(_connectionString);

            try
            {
                await producer.GetEventHubPropertiesAsync();
                _logger.LogInformation("Conexão bem-sucedida ao Event Hub.");
                
            }
            catch (Exception ex)
            {               
                _logger.LogError($"Erro na conexão: {ex.Message}");
            }

        }

        public async Task EnviarSimulacaoAsync(ResultadoFinalSimulacao simulacao)
        {
            var json = JsonSerializer.Serialize(simulacao);
            var evento = new EventData(Encoding.UTF8.GetBytes(json));

            using EventDataBatch batch = await _producerClient.CreateBatchAsync();
            if (!batch.TryAdd(evento))
                throw new Exception("Evento é grande demais para o batch.");

            await _producerClient.SendAsync(batch);
        }
    }

}
