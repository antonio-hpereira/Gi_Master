using AutoMapper;
using GiMaster_Empregado.Data.ValueObjects;
using GiMaster_Empregado.Entidades;
using GiMaster_Empregado.Repository.Abstract;
using GIMaster_Empregado.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GIMaster_Empregado.Repository.Concret
{
    public class EmpregadoRepository : IEmpregadoRepository
    {
        protected EmpregadoContext _context;
        private IMapper _mapper;

        public EmpregadoRepository(EmpregadoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmpregadoVO> Create(EmpregadoVO vo)
        {

            vo.DataExclusao = DateTime.MaxValue;
            if (vo.ID == Guid.Empty)
                vo.ID = Guid.NewGuid();

            if (vo.UniqueKey == Guid.Empty)
                vo.UniqueKey = Guid.NewGuid();

            if (vo.DataInclusao.CompareTo(DateTime.MinValue) == 0 || vo.DataInclusao.CompareTo(DateTime.MaxValue) == 0)
                vo.DataInclusao = DateTime.Now;
           

            Empregados empregado = _mapper.Map<Empregados>(vo);

            _context.Empregados.Add(empregado);

            await _context.SaveChangesAsync();
            return _mapper.Map<EmpregadoVO>(empregado);
        }

        public async Task<EmpregadoVO> Update(EmpregadoVO vo)
        {
            Empregados empregados = _mapper.Map<Empregados>(vo);
            _context.Empregados.Update(empregados);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmpregadoVO>(empregados);
        }

        public async Task<IEnumerable<EmpregadoVO>> FindAll()
        {
            List<Empregados> empregados = await _context.Empregados.Where(x => string.IsNullOrEmpty(x.UsuarioExclusao)).ToListAsync();
            return _mapper.Map<List<EmpregadoVO>>(empregados);
        }

        public async Task<EmpregadoVO> FindById(Guid uniquekey)
        {
            Empregados empregados = await _context.Empregados.Where(x => string.IsNullOrEmpty(x.UsuarioExclusao) && x.UniqueKey == uniquekey)
                .FirstOrDefaultAsync();
            return _mapper.Map<EmpregadoVO>(empregados);
        }

        public async Task<bool> Delete(Guid uniquekey)
        {
            try
            {
                Empregados empregados =
                await _context.Empregados.Where(x => string.IsNullOrEmpty(x.UsuarioExclusao) && x.UniqueKey == uniquekey)
                    .FirstOrDefaultAsync();
                empregados.DataExclusao = DateTime.Now;

                if (empregados == null) return false;

                _context.Entry(empregados).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                //_context.Empregados.Remove(empregados);              

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

       
    }
}
