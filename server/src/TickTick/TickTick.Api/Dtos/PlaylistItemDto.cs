using System;
using TickTick.Models;

namespace TickTick.Api.Dtos
{
	public interface IPlaylistItemDto
	{
        public string Title { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public string Performer { get; set; }
	}
}

