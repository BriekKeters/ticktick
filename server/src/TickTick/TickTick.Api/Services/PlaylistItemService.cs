using System;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;

namespace TickTick.Api.Services
{
    public class PlaylistItemService : IPlaylistItemService
    {
        public PlaylistItemService()
        {
        }

        public void DeleteItem(PlaylistItem p)
        {
            p.Delete();
        }
        public PlaylistItem AddItem(PlaylistItemDto dto)
        {
            PlaylistItem song = new PlaylistItem(dto.Title, dto.Performer, dto.Type);
            song.CreatePublicId();
            return song;
        }
    }
}

