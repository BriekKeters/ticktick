using System;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Repositories.Base;
using TickTick.Api.RequestHandlers.PlaylistItems;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class SpeechController:ApiControllerBase
	{
        private readonly IRepository<PlaylistItem> _repo;

        public SpeechController(IRepository<PlaylistItem> repo,IMediator mediator):base(mediator)
		{
            this._repo = repo;
		}

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PlaylistItemDto>), 204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExecuteRequest(new DeletePlaylistItemRequest(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PlaylistItemDto>), 201)]
        public async Task<IActionResult> Post([FromBody] PlaylistItemDto dto)
        {
            return await ExecuteRequest(new PostPlaylistRequest(dto));
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PlaylistItemDto>), 201)]
        public async Task<IActionResult> Put(Guid id, [FromBody] PlaylistItemDto dto)
        {
            return await ExecuteRequest(new PutPlaylistItemRequest(dto, id));
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PlaylistItemDto>), 200)]
        public async Task<IActionResult> Get()
        {
            return await ExecuteRequest(new GetAllPlaylistItemRequest(PlaylistItemType.Speech));

        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<PlaylistItemDto>), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExecuteRequest(new GetPlaylistItemRequest(id, PlaylistItemType.Speech));

        }
    }
}

