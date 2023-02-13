using System;
namespace TickTick.Models
{
	public class Song:PlaylistItem
	{
		public Uri Url { get; set; }

        public Song()
        {
            Type = PlaylistItemType.Song;
        }
        public void Update(string title, string performer,Uri url)
        {
            this.Title = title;
            this.Performer = performer;
            this.Url = url;
        }
    }
}

