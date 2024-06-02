using GIMaster_Empregados.Context;
using GIMaster_Empregados.Data.Shared;
using GIMaster_Empregados.Data.ValueObjects;
using GIMaster_Empregados.Repository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GIMaster_Empregados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpregadosController : ControllerBase
    {
        private IEmpregadoRepository _empregadoRepository;
        protected EmpregadosContext _context;

        public EmpregadosController(IEmpregadoRepository empregadoRepository, EmpregadosContext context)
        {
            _empregadoRepository = empregadoRepository;
            _context = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<EmpregadoVO>> Create(EmpregadoVO vo)
        {

            if (_context.Empregados.Where(x =>  x.CPF.Equals(vo.CPF) || vo == null).Any())
            {
                var msg = new MessageBase();
                msg.RetornaErro("Empregado com cpf " + vo.CPF + " já existe no sistema!");
                //string json = JsonSerializer.Deserialize(msg);

                return BadRequest(msg);

            }

            var empregado = await _empregadoRepository.Create(vo);

            return Ok(empregado);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<EmpregadoVO>> Update(EmpregadoVO vo)
        {
            if (vo == null) return BadRequest();
            var empregado = await _empregadoRepository.Update(vo);
            return Ok(empregado);
        }
        [HttpGet]
        public async Task<ActionResult<EmpregadoVO>> GetAll()
        {
            var empregado = await _empregadoRepository.FindAll();
            return Ok(empregado);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<EmpregadoVO>> Get(string id)
        {
            Guid ID = Guid.Parse(id);

            if (ID == Guid.Empty) return BadRequest();
            var empregado = await _empregadoRepository.FindById(ID);
            return Ok(empregado);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _empregadoRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }


    }
}
