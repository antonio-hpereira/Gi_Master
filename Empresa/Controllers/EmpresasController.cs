using GIMaster_Empresa.Context;
using GIMaster_Empresa.Data.Shared;
using GIMaster_Empresa.Data.ValueObjects;
using GIMaster_Empresa.Repository.Abstract;
using GIMaster_Empresa.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIMaster_Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository;
        protected EmpresasContext _context;

        public EmpresasController(IEmpresaRepository empresaRepository, EmpresasContext context)
        {
            _empresaRepository = empresaRepository;
            _context = context;
        }

        [Authorize]
        [HttpPost]        
        public async Task<ActionResult<EmpresaVO>> Create(EmpresaVO vo)
        {

            if (_context.Empresas.Where(x => x.cnpj.Equals(vo.cnpj) || vo == null).Any())
            {
                var msg = new MessageBase();
                msg.RetornaErro("Empresa com cnpj " + vo.cnpj + " já existe no sistema!");
                //string json = JsonSerializer.Deserialize(msg);

                return BadRequest(msg);
            }

            var empresa = await _empresaRepository.Create(vo);

            return Ok(empresa);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<EmpresaVO>> Update([FromBody] EmpresaVO vo)
        {
            if (vo == null) return BadRequest();
            var empregado = await _empresaRepository.Update(vo);
            return Ok(empregado);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<EmpresaVO>> GetAll()
        {
            var empresa = await _empresaRepository.FindAll();
            return Ok(empresa);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaVO>> Get(string id)
        {
            Guid ID = Guid.Parse(id);
            if (ID == Guid.Empty) return BadRequest();
            var empregado = await _empresaRepository.FindById(ID);
            return Ok(empregado);
        }

        [HttpDelete("{id}")]
        [Authorize]
        //[Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _empresaRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
