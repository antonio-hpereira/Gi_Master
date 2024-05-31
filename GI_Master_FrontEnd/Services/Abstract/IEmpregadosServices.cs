using GI_Master_FrontEnd.ViewModels;

namespace GI_Master_FrontEnd.Services.Abstract
{
    public interface IEmpregadosServices
    {
        Task<IEnumerable<EmpregadoVM>> FindAllEmpregados(string token);
        Task<EmpregadoVM> FindEmpregadoById(string id, string token);
        Task<EmpregadoVM> CreateEmpregado(EmpregadoVM model, string token);
        Task<EmpregadoVM> UpdateEmpregado(EmpregadoVM model, string token);
        Task<bool> DeleteEmpregadoById(string id, string token);
    }
}
