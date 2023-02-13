using System;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;

namespace TickTick.Api.Services
{
	public class PlaylistItemService
	{
		public PlaylistItemService()
		{
		}

        public void DeleteItem(PlaylistItem p)
        {
            p.Delete();
        }
        public PlaylistItem AddSong(Song dto)
        {
            PlaylistItem song = new PlaylistItem()
            {
                Title = dto.Title,
                Performer = dto.Performer
            };
            song.CreatePublicId();
            return song;
        }
    }
}

