using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos;
using TickTick.Models;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<LocationDto>), 200)]
        public IActionResult Get()
        {
            Location lo = new Location("Bergenstraat", "2", "Gent", "9000", "Belgie");
            return Ok(lo.ConvertToDto());
        }
    }
}
