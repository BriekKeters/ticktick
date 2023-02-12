using System;
namespace TickTick.Models
{
	public class Song:PlaylistItem
	{
		public Uri Url { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Title { get; set; }
        public uint SequenceNumber { get; set; }
    }
}

