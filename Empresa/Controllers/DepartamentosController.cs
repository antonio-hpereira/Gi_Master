using GIMaster_Empresa.Context;
using GIMaster_Empresa.Data.Shared;
using GIMaster_Empresa.Data.ValueObjects;
using GIMaster_Empresa.Repository.Abstract;
using GIMaster_Empresa.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GIMaster_Empresa.Controllers
{
    [Route("api/Departamentos")]
    [ApiController]
    public class DepartamentosController : Controller
    {
        private IDepartamentoRepository _departamentoRepository;
        protected EmpresasContext _departamentoContext;

        public DepartamentosController(IDepartamentoRepository departamentoRepository, EmpresasContext empresas)
        {
            _departamentoRepository = departamentoRepository;
            _departamentoContext = empresas;

        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DepartamentosVO>> Create(DepartamentosVO vo)
        {

            if (_departamentoContext.Departamentos.Where(x => x.Nome.Equals(vo.Nome) || vo == null).Any())
            {
                var msg = new MessageBase();
                msg.RetornaErro("Departamento " + vo.Nome + " já existe no sistema!");
                //string json = JsonSerializer.Deserialize(msg);
                return BadRequest(msg);
            }
            var departamento = await _departamentoRepository.Create(vo);
            return Ok(departamento);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<DepartamentosVO>> GetAll()
        {
            var depatamento = await _departamentoRepository.FindAll();
            return Ok(depatamento);
        }
    }
}
