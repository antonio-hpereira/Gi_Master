using GIMaster_Empresa.Data.ValueObjects;

namespace GIMaster_Empresa.Repository.Abstract
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<EmpresaVO>> FindAll();
        Task<EmpresaVO> FindById(Guid uniquekey);
        Task<EmpresaVO> Create(EmpresaVO vo);
        Task<EmpresaVO> Update(EmpresaVO vo);
        Task<bool> Delete(Guid uniquekey);
    }
}
