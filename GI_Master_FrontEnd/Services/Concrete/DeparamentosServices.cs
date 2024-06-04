using GI_Master_FrontEnd.Services.Abstract;
using GI_Master_FrontEnd.Utils;
using GI_Master_FrontEnd.ViewModels;
using System.Net.Http.Headers;

namespace GI_Master_FrontEnd.Services.Concrete
{
    public class DeparamentosServices : IDepartamentoServices
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Departamentos";
        public DeparamentosServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }        
              

        public async Task<IEnumerable<DepartamentosVM>> FindAllDepartamentos(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync(BasePath);

            return await response.ReadContentAs<List<DepartamentosVM>>();

        }

        public Task<DepartamentosVM> FindDepartamentosByID(string id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentosVM> UpdateDepartamentos(DepartamentosVM model, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<DepartamentosVM> CreateDepartamentos(DepartamentosVM model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);            
            var response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<DepartamentosVM>();
            else throw new Exception("Something went wrong when calling API");
        }      

        public Task<bool> DeleteDepartamentosById(string id, string token)
        {
            throw new NotImplementedException();
        }
    }
}
