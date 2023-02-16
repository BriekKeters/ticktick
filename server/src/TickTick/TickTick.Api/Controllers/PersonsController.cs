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
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExecuteRequest(new GetPersonRequest(id));
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await ExecuteRequest(new DeletePersonRequest(id));
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<AddPersonDto>), 201)]
        public async Task<IActionResult> Post([FromBody] AddPersonDto person)
        {
            return await ExecuteRequest(new PostPersonRequest(person));
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 201)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PersonDto dto)
        {
            return await ExecuteRequest(new PutPersonRequest(id, dto));
        }
    }
}
