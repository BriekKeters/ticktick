using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Models;

namespace TickTick.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private IList<Person> People { get; set; } = new List<Person>();
        [HttpGet]
        public IActionResult Get()
        {
            People.Add(new Person("John", "Doe", "john@mail.com"));
            People.Add(new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com"));
            return Ok(People);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            //TODO: Haal een persoon op
            Person person = new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com");
            return Ok(person.ConvertToDto());
        }
    }
}
