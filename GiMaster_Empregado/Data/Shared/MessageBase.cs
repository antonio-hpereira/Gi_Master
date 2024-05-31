using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace GiMaster_Empregado.Data.Shared
{
    public  class MessageBase
    {
        [JsonProperty("Erro")]
        public  string Erro { get; set; }

        [JsonProperty("Alerta")]
        public  string Alerta { get; set; }

        [JsonProperty("Sucesso")]
        public  string Sucesso { get; set; }

        [JsonProperty("URL")]
        public  string URL { get; set; }

        [JsonProperty("Conteudo")]
        public  string Conteudo { get; set; }

        public  string RetornaErro(string erro)
        {
            this.Erro = erro;

            return Erro;
        }
    }
}
