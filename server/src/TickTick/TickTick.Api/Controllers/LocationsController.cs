using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Models;

namespace TickTick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Location lo = new Location("Bergenstraat", "2", "Gent", "9000", "Belgie");
            return Ok(lo.ConvertToDto());
        }
    }
}
