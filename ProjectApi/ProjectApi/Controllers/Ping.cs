using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ping : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok("Pong");
        }
    }
}
