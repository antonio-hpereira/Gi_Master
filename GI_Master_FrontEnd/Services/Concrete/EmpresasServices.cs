using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Utils;
using GI_Master_FrontEnd.ViewModels;
using System.Net.Http.Headers;

namespace GI_Master_FrontEnd.Services.Concrete
{
    public class EmpresasServices : IEmpresasServices
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Empresas";
        public EmpresasServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<EmpresasVM> CreateEmpresa(EmpresasVM model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<EmpresasVM>();
            else throw new Exception("Something went wrong when calling API");

        }
        public async Task<IEnumerable<EmpresasVM>> FindAllEmpresas(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);
           
                return await response.ReadContentAs<List<EmpresasVM>>();


        }

        public async Task<EmpresasVM> FindEmpresasByID(string id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<EmpresasVM>();
        }


        public async Task<EmpresasVM> UpdateEmpresa(EmpresasVM model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<EmpresasVM>();
            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> DeleteEmpresaById(string id, string token)
        {
            Guid ID = Guid.Parse(id);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($"{BasePath}/{ID}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else throw new Exception("Something went wrong when calling API");
        }
    }
}
