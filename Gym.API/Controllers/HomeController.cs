using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        
        [HttpGet]
        public IActionResult Get() => Ok("Swagger works!");
    }
}
