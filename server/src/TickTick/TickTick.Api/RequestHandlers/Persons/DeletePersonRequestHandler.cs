using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
	public class DeletePersonRequest : QueryBase<PersonDto>
	{

        public Guid PublicId { get; }

        public DeletePersonRequest(Guid publicId)
		{
            PublicId = publicId;
        }
    }
	public class DeletePersonRequestHandler: IRequestHandler<DeletePersonRequest, PersonDto>
	{
        private readonly IRepository<Person> personRepo;

        public DeletePersonRequestHandler(IRepository<Person> personRepo)
		{
            this.personRepo = personRepo;
        }

        public async Task<PersonDto> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var p = await personRepo.GetAsync(p => p.PublicId == request.PublicId && p.IsDeleted == false);
            p.Delete();
            await personRepo.SaveAsync();
            return p.ConvertToDto();
        }
    }
}

