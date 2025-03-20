using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly CepService _cepService;

        public CepController(CepService cepService)
        {
            _cepService = cepService;
        }

        [HttpGet("validar/{cep}")]
        public async Task<IActionResult> ValidarCep(string cep)
        {
            var isValid = await _cepService.ValidarCepAsync(cep);
            if (isValid)
            {
                return Ok(new { valido = true });
            }
            else
            {
                return BadRequest(new { valido = false });
            }
        }
    }
}
