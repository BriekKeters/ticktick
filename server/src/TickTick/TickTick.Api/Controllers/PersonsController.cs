using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.RequestHandlers.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class PersonsController : ApiControllerBase
    {
        private readonly IPersonsService svc;
        private readonly IRepository<Person> _repo;

        private IList<Person> People { get; set; } = new List<Person>();

        public PersonsController(IPersonsService service, IRepository<Person> repo, IMediator mediator):base(mediator)
        {
            this.svc = service;
            this._repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllPersonsRequest());
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
        public async Task<IActionResult> Delete(Guid id)
        {
            Person p = await _repo.GetAsync(p => p.PublicId == id);
            svc.DeletePerson(p);

            _repo.Delete(p);
            await _repo.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Post([FromBody] AddPersonDto person)
        {
            PersonDto p = svc.AddPerson(person);
            Person neP = new Person(person.FirstName, person.LastName, person.Email);
            _repo.Add(neP);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = p.PublicId }, p);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Put(Guid id, [FromBody]PersonDto dto)
        {
            Person p = await _repo.GetAsync(p => p.PublicId == id);

            PersonDto newP = svc.UpdatePerson(p, dto);
            _repo.Update(p);
            await _repo.SaveAsync();
            return Ok(newP);
        }
    }
}
