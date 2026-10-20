using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFinanceiro.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("teste")]
        public async Task<IActionResult> Get()
        {
            return Ok("teste");
        }
    }
}
