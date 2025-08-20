using API_Loan_Simulator.Context;
using API_Loan_Simulator.Core_Simulator;
using API_Loan_Simulator.Core_Simulator.ISimulator;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Loan_Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanSimulatorController : ControllerBase
    {
        DBHack_Context _context;
        private readonly ISimuladorFinanciamento _simulador;
       
        public LoanSimulatorController(DBHack_Context context, ISimuladorFinanciamento simulador)
        {
            _context = context;
            _simulador = simulador;
            
        }

        
        // POST api/<LoanSimulatorController>
        [HttpPost("calcular")]
        public IActionResult CalcularSimulacao([FromBody] DadosSimulacao dados)
        {
            var resultados = _simulador.Simular(dados);
            return Ok(resultados);
        }

        
    }
}
