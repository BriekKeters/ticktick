using System;
using TickTick.Models;

namespace TickTick.Api.Dtos
{
    public class SpeechDto
    {
        public string Text { get; set; }
        public string Speaker { get; set; }
        public string Title { get; set; }
    }

    public static class SpeechExtensions
    {
        public static SpeechDto ConvertToDto(this Speech speech)
        {
            return new SpeechDto()
            {
                Title = speech.Title,
                Text = speech.Text,
                Speaker =speech.Performer
            };
        }
    }
}

