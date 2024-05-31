using GI_Master_FrontEnd.ViewModels;

namespace GI_Master_FrontEnd.Services.Abstract
{
    public interface IEmpresasServices
    {
        Task<IEnumerable<EmpresasVM>> FindAllEmpresas(string token);
        Task<EmpresasVM> FindEmpresasByID(string id, string token);
        Task<EmpresasVM> CreateEmpresa(EmpresasVM model, string token);
        Task<EmpresasVM> UpdateEmpresa(EmpresasVM model, string token);        
        Task<bool> DeleteEmpresaById(string id, string token);


    }
}
