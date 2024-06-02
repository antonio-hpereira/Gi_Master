using GI_Master_FrontEnd.ViewModels;

namespace GI_Master_FrontEnd.Services.Abstract
{
    public interface IDepartamentoServices
    {
        Task<IEnumerable<DepartamentosVM>> FindAllDepartamentos(string token);
        Task<DepartamentosVM> FindDepartamentosByID(string id, string token);
        Task<DepartamentosVM> CreateDepartamentos(DepartamentosVM model, string token);
        Task<DepartamentosVM> UpdateDepartamentos(DepartamentosVM model, string token);
        Task<bool> DeleteDepartamentosById(string id, string token);

    }
}
