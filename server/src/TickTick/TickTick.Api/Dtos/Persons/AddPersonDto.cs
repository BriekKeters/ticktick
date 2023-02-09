using System;
namespace TickTick.Api.Dtos.Persons
{
	public record AddPersonDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
	}
    public record UpdatePersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

