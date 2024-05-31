using AutoMapper;
using GIMaster_Empresa.Context;
using GIMaster_Empresa.Data.ValueObjects;
using GIMaster_Empresa.Entidades;
using GIMaster_Empresa.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empresa.Repository.Concrete
{
    public class EmpresaRepository : IEmpresaRepository
    {
        protected EmpresasContext _context;
        private IMapper _mapper;

        public EmpresaRepository(EmpresasContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpresaVO> Create(EmpresaVO vo)
        {
            Empresas empresas = _mapper.Map<Empresas>(vo);

            if(empresas.ID == Guid.Empty)            
                empresas.ID = Guid.NewGuid();
            
            if (empresas.Status == string.Empty || empresas.Status == null)
                empresas.Status = "livre";

            _context.Empresas.Add(empresas);
            _context.SaveChanges();

            return _mapper.Map<EmpresaVO>(empresas);

        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {

                Empresas empresas =
                await _context.Empresas.Where(x => x.ID == id)
                    .FirstOrDefaultAsync();

                if (empresas == null) return false;
                _context.Empresas.Remove(empresas);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<EmpresaVO>> FindAll()
        {
            List<Empresas> empresas = await _context.Empresas.ToListAsync();
            return _mapper.Map<List<EmpresaVO>>(empresas);
        }

        public async Task<EmpresaVO> FindById(Guid id)
        {
            Empresas empresa = await _context.Empresas.Where(x => (x.ID == id))
              .FirstOrDefaultAsync();
            return _mapper.Map<EmpresaVO>(empresa);
        }

        public async Task<EmpresaVO> Update(EmpresaVO vo)
        {
            Empresas empresas = _mapper.Map<Empresas>(vo);
            empresas.Status = "livre";
            _context.Empresas.Update(empresas);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpresaVO>(empresas);   
        }
    }
}
