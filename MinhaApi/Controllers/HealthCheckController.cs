using Microsoft.AspNetCore.Mvc;
using MinhaApi.Interfaces;

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly IHealthCheck _healthCheck;

        public HealthCheckController(IHealthCheck healthCheck)
        {
            _healthCheck = healthCheck;
        }

        [HttpGet]
        public ActionResult<bool> VerificarSaudeDoServico()
        {
            var saudavel = _healthCheck.EstaSaudavel();
            return Ok(saudavel);
        }
    }
}