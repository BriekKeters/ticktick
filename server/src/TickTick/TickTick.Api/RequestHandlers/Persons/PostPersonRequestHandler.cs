using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
	public class PostPersonRequest: CommandBase<AddPersonDto>
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public PostPersonRequest(AddPersonDto dto)
		{
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
        }
    }

    public class PostPersonRequestHandler : IRequestHandler<PostPersonRequest, AddPersonDto>
    {
        private readonly IRepository<Person> personRepo;

        public PostPersonRequestHandler(IRepository<Person> personRepo)
        {
            this.personRepo = personRepo;
        }
        public async Task<AddPersonDto> Handle(PostPersonRequest request, CancellationToken cancellationToken)
        {
            Person person = new Person(request.FirstName, request.LastName, request.Email);
            person.CreatePublicId();
            personRepo.Add(person);
            await personRepo.SaveAsync();
            return new AddPersonDto();
        }
    }
}

