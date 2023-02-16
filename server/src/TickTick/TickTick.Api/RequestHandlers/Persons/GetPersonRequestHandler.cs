using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
	public class GetPersonRequest : QueryBase<PersonDto>
	{
        public Guid PublicId { get; }

        public GetPersonRequest(Guid publicId)
		{
            PublicId = publicId;
        }

    }
	public class GetPersonRequestHandler : IRequestHandler<GetPersonRequest, PersonDto>
	{
        private readonly IRepository<Person> personRepo;

        public GetPersonRequestHandler(IRepository<Person> personRepo)
		{
            this.personRepo = personRepo;
        }

        public async Task<PersonDto> Handle(GetPersonRequest request, CancellationToken cancellationToken)
        {
            var p = await personRepo.GetAsync(p => p.PublicId == request.PublicId && p.IsDeleted == false);
            return p.ConvertToDto();
        }
    }
}

