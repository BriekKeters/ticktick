using System;
using TickTick.Models;

namespace TickTick.Api.Dtos
{
    public class SongDto : IPlaylistItemDto
    {
        public Uri Url { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public string Performer { get; set; }
    }
    public static class SongExtensions
    {
        public static SongDto ConvertToDto(this Song song)
        {
            return new SongDto()
            {
                Title = song.Title,
                Url = song.Url,
                Performer =song.Performer
            };
        }
    }
}

