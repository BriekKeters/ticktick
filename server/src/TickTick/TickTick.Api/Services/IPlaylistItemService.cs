using TickTick.Api.Dtos;
using TickTick.Models;

namespace TickTick.Api.Services
{
    public interface IPlaylistItemService
    {
        PlaylistItem AddItem(PlaylistItemDto dto);
        void DeleteItem(PlaylistItem p);
    }
}