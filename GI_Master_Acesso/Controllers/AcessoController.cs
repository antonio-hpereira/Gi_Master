using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GI_Master_Acesso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcessoController : ControllerBase
    {
        private readonly ILogger<AcessoController> _logger;

        public AcessoController(ILogger<AcessoController> logger)
        {
            _logger = logger;
        }

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
            
        //    return Ok();
        //}

        // GET: api/<AcessoController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AcessoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AcessoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AcessoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AcessoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
