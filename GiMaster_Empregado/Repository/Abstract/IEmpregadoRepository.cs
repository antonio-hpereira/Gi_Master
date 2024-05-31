using GiMaster_Empregado.Data.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiMaster_Empregado.Repository.Abstract
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
