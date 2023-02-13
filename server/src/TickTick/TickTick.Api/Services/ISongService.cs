using TickTick.Api.Dtos;
using TickTick.Models;

namespace TickTick.Api.Services
{
    public interface ISongService
    {
        Song AddSong(SongDto dto);
        SongDto UpdateSong(Song p, SongDto dto);
        void DeleteItem(PlaylistItem p);
    }
}