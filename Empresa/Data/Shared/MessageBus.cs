using System.Text.Json.Serialization;

namespace GIMaster_Empresa.Data.Shared
{
    public class MessageBase
    {
        [JsonPropertyName("Erro")]
        public string Erro { get; set; }

        [JsonPropertyName("Alerta")]
        public string Alerta { get; set; }

        [JsonPropertyName("Sucesso")]
        public string Sucesso { get; set; }

        [JsonPropertyName("URL")]
        public string URL { get; set; }

        [JsonPropertyName("Conteudo")]
        public string Conteudo { get; set; }

        public string RetornaErro(string erro)
        {
            this.Erro = erro;

            return Erro;
        }
    }
}
