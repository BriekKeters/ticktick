using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Api.Services;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.Controllers
{
    [Route("/v{v:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class SongController:ControllerBase
	{
        private readonly ISongService _svc;
        private readonly IRepository<PlaylistItem> _repo;

        public SongController(ISongService svc, IRepository<PlaylistItem> repo)
		{
            this._svc = svc;
            this._repo = repo;
		}

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<SongDto>), 204)]
        public async Task<IActionResult> Delete(Guid id)
        {
            PlaylistItem song = await _repo.GetAsync(song => song.PublicId == id && song.Type == PlaylistItemType.Song);
            _svc.DeleteItem(song);

            _repo.Delete(song);
            await _repo.SaveAsync();
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<SongDto>), 201)]
        public async Task<IActionResult> Post([FromBody] SongDto dto)
        {
            Song song = _svc.AddSong(dto);
            _repo.Add(song);
            await _repo.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = song.PublicId }, song.ConvertToDto());
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<SongDto>), 201)]
        public async Task<IActionResult> Put(Guid id, [FromBody] SongDto dto)
        {
            var p = await _repo.GetAsync(p => p.PublicId == id && p.Type == PlaylistItemType.Song);

            _svc.UpdateSong((Song)p, dto);
            _repo.Update(p);
            await _repo.SaveAsync();
            return Ok(p);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(IEnumerable<SongDto>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var songs = await _repo.GetAllAsync(p => p.IsDeleted == false &&p.Type ==PlaylistItemType.Song);

                Response<IEnumerable<PlaylistItem>> resp = new Response<IEnumerable<PlaylistItem>>();
                resp.Data = songs;
                return Ok(resp);

            }
            catch (Exception ex)
            {
                Response<IEnumerable<PlaylistItem>> r = new Response<IEnumerable<PlaylistItem>>();
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
        [ProducesResponseType(typeof(IEnumerable<SongDto>), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            var p = await _repo.GetAsync(p => p.PublicId == id && p.Type == PlaylistItemType.Song);
            return Ok(p);
        }
    }
}

