using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Utils;
using GI_Master_FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace GI_Master_FrontEnd.Services.Concrete
{
    public class EmpregadosServices : IEmpregadosServices
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Empregados";

        public EmpregadosServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<EmpregadoVM> CreateEmpregado(EmpregadoVM model, string token)
        {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _client.PostAsJson(BasePath, model);
                if (response.IsSuccessStatusCode)
                    return await response.ReadContentAs<EmpregadoVM>();
                else throw new Exception("Something went wrong when calling API");
                      
        }

        public async Task<bool> DeleteEmpregadoById(string ID, string token)
        {
            Guid id = Guid.Parse(ID);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<EmpregadoVM>> FindAllEmpregados(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<EmpregadoVM>>();
        }

        public async Task<EmpregadoVM> FindEmpregadoById(string id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<EmpregadoVM>();
        }

        public async Task<EmpregadoVM> UpdateEmpregado(EmpregadoVM model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<EmpregadoVM>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
