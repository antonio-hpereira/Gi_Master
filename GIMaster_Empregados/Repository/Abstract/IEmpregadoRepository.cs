using GIMaster_Empregados.Data.ValueObjects;

namespace GIMaster_Empregados.Repository.Abstract
{
    public interface IEmpregadoRepository
    {
        Task<IEnumerable<EmpregadoVO>> FindAll();
        Task<EmpregadoVO> FindById(Guid uniquekey);
        Task<EmpregadoVO> Create(EmpregadoVO vo);
        Task<EmpregadoVO> Update(EmpregadoVO vo);
        Task<bool> Delete(Guid uniquekey);
    }
}
