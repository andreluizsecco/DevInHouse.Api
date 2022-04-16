using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AmbienteController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AmbienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult<string> ObterNomeSistema()
        {
            var nomeSistema = _configuration.GetSection("NomeDoSistema").Value;
            return Ok(nomeSistema);
        }
    }
}