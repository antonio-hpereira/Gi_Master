using API_Loan_Simulator.Context;
using API_Loan_Simulator.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Loan_Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaSimulacoesController : ControllerBase
    {
        MemoryContext _context;
        public ListaSimulacoesController(MemoryContext context)
        {
            _context = context;
        }
        // GET: api/<ListaSimulacoesController>
        [HttpGet]
        public IEnumerable<Simulacao> Get()
        {
            var simulacoes = _context.Simulacoes
                .Include(s => s.Parcelas) // Inclui as parcelas relacionadas
                .ToList(); // Obtém a lista de simulações com suas parcelas



            return simulacoes;
        }

        // GET api/<ListaSimulacoesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListaSimulacoesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListaSimulacoesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListaSimulacoesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
