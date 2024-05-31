using AutoMapper;
using GIMaster_Empregados.Context;
using GIMaster_Empregados.Data.ValueObjects;
using GIMaster_Empregados.Entidades;
using GIMaster_Empregados.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empregados.Repository.Concrete
{

    public class EmpregadoRepository : IEmpregadoRepository
    {
        protected EmpregadosContext _context;
        private IMapper _mapper;

        public EmpregadoRepository(EmpregadosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpregadoVO> Create(EmpregadoVO vo)
        {
            Empregados empregado = _mapper.Map<Empregados>(vo);            

            if (empregado.ID == Guid.Empty)
                empregado.ID = Guid.NewGuid();           

            if (empregado.Status == string.Empty || empregado.Status == null)
                empregado.Status = "livre";

            _context.Empregados.Add(empregado);

            await _context.SaveChangesAsync();

            return _mapper.Map<EmpregadoVO>(empregado);
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                Empregados empregados =
                await _context.Empregados.Where(x =>  x.ID == id)
                    .FirstOrDefaultAsync();             

                if (empregados == null) return false;
                _context.Empregados.Remove(empregados);
                await _context.SaveChangesAsync();   
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<EmpregadoVO>> FindAll()
        {
            List<Empregados> empregados = await _context.Empregados.ToListAsync();
            return _mapper.Map<List<EmpregadoVO>>(empregados);
        }

        public async Task<EmpregadoVO> FindById(Guid id)
        {
            Empregados empregados = await _context.Empregados.Where(x => (x.ID == id))
                .FirstOrDefaultAsync();
            return _mapper.Map<EmpregadoVO>(empregados);
        }

        public async Task<EmpregadoVO> Update(EmpregadoVO vo)
        {          

            Empregados empregados = _mapper.Map<Empregados>(vo);

            empregados.Status = "livre";
            _context.Empregados.Update(empregados);
            await _context.SaveChangesAsync();           
            return _mapper.Map<EmpregadoVO>(empregados);
        }
    }
}

