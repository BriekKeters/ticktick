using System;
namespace TickTick.Models
{
    public enum PlaylistItemType
    {
        Song,
        Speech
    }
	public class PlaylistItem: BaseAuditableEntity
	{
        public Guid PublicId { get; set; }
        public TimeSpan? Duration { get; set; }
        public string Title { get; set; }
        public uint SequenceNumber { get; set; }
        public string? Text { get; set; }
        public string? Description { get; set; }
        public string Artist { get; set; }
        public string  Performer { get; set; }
        public PlaylistItemType Type { get; set; }
    }
}

