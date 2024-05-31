using GiMaster_Empregado.Data.Shared;
using GiMaster_Empregado.Data.ValueObjects;
using GiMaster_Empregado.Repository.Abstract;
using GIMaster_Empregado.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace GiMaster_Empregado.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpregadoController : ControllerBase
    {
       
        private IEmpregadoRepository _empregadoRepository;
        protected EmpregadoContext _context;

        public EmpregadoController(IEmpregadoRepository empregadoRepository, EmpregadoContext context)
        {
            _empregadoRepository = empregadoRepository;
            _context = context;
        }

        [HttpPost]       
        public async Task<ActionResult<EmpregadoVO>> Create([FromBody] EmpregadoVO vo)
        {

            if (_context.Empregados.Where(x =>string.IsNullOrEmpty(x.UsuarioExclusao) && x.CPF.Equals(vo.CPF) || vo == null).Any())
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
        public async Task<ActionResult<EmpregadoVO>> Update([FromBody] EmpregadoVO vo)
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

        [HttpGet("{uniquekey}")]
        public async Task<ActionResult<EmpregadoVO>> Get(Guid uniquekey)
        {
            if (uniquekey == Guid.Empty) return BadRequest();
            var empregado = await _empregadoRepository.FindById(uniquekey);
            return Ok(empregado);
        }

        [HttpDelete("{uniquekey}")]
        //[Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var status = await _empregadoRepository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }




    }
}
