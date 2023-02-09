using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Models.Dtos;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsService svc;

        private IList<Person> People { get; set; } = new List<Person>();

        public PersonsController(IPersonsService service)
        {
            this.svc = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Get()
        {
            try { 
                People.Add(new Person("John", "Doe", "john@mail.com"));
                People.Add(new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com"));

                Response<IEnumerable<Person>> resp = new Response<IEnumerable<Person>>();
                resp.Data = People;
                return Ok(resp);

            }
            catch(Exception ex)
            {
                Response < IEnumerable < Person >> r = new Response<IEnumerable<Person>>();
                r.Data = null;
                r.Message = ex.Message;
                r.Status = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode(500, r);
            }
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public IActionResult Get(Guid id)
        {
            //TODO: Haal een persoon op
            Person person = new Person("Kevin", "DeRudder", "kevin.derudder@gmail.com");
            return Ok(person.ConvertToDto());
        }

        [HttpGet("/v{v:apiVersion}/[controller]/{id:Guid}/locations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<LocationDto>), 200)]
        public IActionResult GetPersonLocation(Guid id)
        {
            //TODO: Haal een persoon op
            List<Location> locations = new()
            {
                new Location("Ghent", "Belgium"),
                new Location("Aalst", "Belgium"),
                new Location("Poperinge", "Belgium"),
                new Location("Kortrijk", "Belgium"),
                new Location("Mechelen", "Belgium"),

            };
            List<LocationDto> dtos = new List<LocationDto>();
            locations.ForEach(loc => { dtos.Add(loc.ConvertToDto()); });
            return Ok(new Response<IEnumerable<LocationDto>>(dtos));
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 204)]
        public IActionResult Delete(Guid id)
        {
            svc.DeletePerson(id);
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public IActionResult Post([FromBody] AddPersonDto person)
        {
            PersonDto p = svc.AddPerson(person);
            return CreatedAtAction(nameof(Get), new { id = p.PublicId }, person);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public IActionResult Put(Guid id, [FromBody]PersonDto dto)
        {
            PersonDto newP = svc.UpdatePerson(id, dto);
            return Ok(newP);
        }
    }
}
