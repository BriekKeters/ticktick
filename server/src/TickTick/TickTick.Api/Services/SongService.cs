using System;
using TickTick.Api.Dtos;
using TickTick.Models;

namespace TickTick.Api.Services
{
    public class SongService : PlaylistItemService, ISongService
    {
        public SongService()
        {
        }
        public Song AddSong(SongDto dto)
        {
            Song song = new Song()
            {
                Url = dto.Url,
                Title = dto.Title,
                Performer = dto.Performer
            };
            song.CreatePublicId();
            return song;
        }
        public SongDto UpdateSong(Song p, SongDto dto)
        {
            p.Update(dto.Title,dto.Performer,dto.Url);
            return p.ConvertToDto();
        }
    }
}

