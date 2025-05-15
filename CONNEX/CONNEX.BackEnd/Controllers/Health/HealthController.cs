using Microsoft.AspNetCore.Mvc;

namespace CONNEX.BackEnd.Controllers.Health
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {

        // Punto final para verificar la salud de la aplicación
        [HttpGet("healthy")]
        public IActionResult GetHealthStatus()
        {
            // Puedes agregar lógica aquí para verificar servicios o recursos críticos
            var healthStatus = new
            {
                Status = "Healthy",
                Timestamp = DateTime.UtcNow
            };

            return Ok(healthStatus); // Devuelve un código 200 OK con los detalles
        }
    }
}
