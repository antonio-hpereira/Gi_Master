using AutoMapper;
using GIMaster_Empresa.Context;
using GIMaster_Empresa.Data.ValueObjects;
using GIMaster_Empresa.Entidades;
using GIMaster_Empresa.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empresa.Repository.Concrete
{
    public class DepartamentoRepository : IDepartamentoRepository
    {

        protected EmpresasContext _context;
        private IMapper _mapper;

        public DepartamentoRepository(EmpresasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DepartamentosVO> Create(DepartamentosVO vo)
        {
            Departamentos departamentos = _mapper.Map<Departamentos>(vo);

            if (departamentos.ID == Guid.Empty)
                departamentos.ID = Guid.NewGuid();
           

            _context.Departamentos.Add(departamentos);
            _context.SaveChanges();

            return _mapper.Map<DepartamentosVO>(departamentos);
        }

        public Task<bool> Delete(Guid uniquekey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DepartamentosVO>> FindAll()
        {
            List<Departamentos> departamentos = await _context.Departamentos.ToListAsync();
            return _mapper.Map<List<DepartamentosVO>>(departamentos);
        }

        public Task<DepartamentosVO> FindById(Guid uniquekey)
        {
            throw new NotImplementedException();
        }

        public Task<DepartamentosVO> Update(DepartamentosVO vo)
        {
            throw new NotImplementedException();
        }
    }
}
