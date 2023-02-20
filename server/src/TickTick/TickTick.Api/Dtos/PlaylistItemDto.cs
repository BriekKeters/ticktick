using System;
using TickTick.Models;

namespace TickTick.Api.Dtos
{
	public class PlaylistItemDto
	{
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public string Performer { get; set; }
        public PlaylistItemType Type { get; set; }
	}
    public static class PlaylistItemExtension
    {
        public static PlaylistItemDto ConvertToDto(this PlaylistItem person)
        {
            return new PlaylistItemDto()
            {
                Title = person.Title,
                Text = person.Text,
                Description = person.Description,
                Performer = person.Performer,
                Type = person.Type
            };
        }
    }
}

