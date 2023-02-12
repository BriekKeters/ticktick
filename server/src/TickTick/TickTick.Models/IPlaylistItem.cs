using System;
namespace TickTick.Models
{
	public interface IPlaylistItem
	{
		TimeSpan? Duration { get; set; }
		string Title { get; set; }
		uint SequenceNumber { get; set; }
	}
}

