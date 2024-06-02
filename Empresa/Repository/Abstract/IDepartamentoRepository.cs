using GIMaster_Empresa.Data.ValueObjects;

namespace GIMaster_Empresa.Repository.Abstract
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<DepartamentosVO>> FindAll();
        Task<DepartamentosVO> FindById(Guid uniquekey);
        Task<DepartamentosVO> Create(DepartamentosVO vo);
        Task<DepartamentosVO> Update(DepartamentosVO vo);
        Task<bool> Delete(Guid uniquekey);
    }
}
