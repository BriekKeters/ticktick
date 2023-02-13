using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TickTick.Models;

namespace TickTick.Api.Dtos
{
    public class LocationDto
    {
        public string Street { get; set; }
        public string Nr { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
    }
    public static class LocationExtensions
    {
        public static LocationDto ConvertToDto(this Location location)
        {
            return new LocationDto()
            {
                Street = location.Street,
                Nr = location.Nr,
                City = location.City,
                State = location.State,
                ZipCode = location.ZipCode,
                Country = location.Country,
                Type = location.Type.ToString()
            };
        }
    }
}
