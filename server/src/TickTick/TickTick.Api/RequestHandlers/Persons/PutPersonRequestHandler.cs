using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{
	public class PutPersonRequest : CommandBase<PersonDto>
	{
		public PutPersonRequest(Guid publicId, PersonDto dto)
		{
            PublicId = publicId;
            Dto = dto;
        }

        public Guid PublicId { get; }
        public PersonDto Dto { get; }
    }

	public class PutPersonRequestHandler:IRequestHandler<PutPersonRequest,PersonDto>
	{
        private readonly IRepository<Person> personRepo;

        public PutPersonRequestHandler(IRepository<Person> personRepo)
		{
            this.personRepo = personRepo;
        }

        public async Task<PersonDto> Handle(PutPersonRequest request, CancellationToken cancellationToken)
        {
            var p = await personRepo.GetAsync(p => p.PublicId == request.PublicId && p.IsDeleted == false);
            PersonDto dto = request.Dto;
            p.update(dto.FirstName, dto.LastName,dto.MiddleName, dto.DateOfBirth, dto.Email);
            personRepo.Update(p);
            await personRepo.SaveAsync();
            return p.ConvertToDto();
        }
    }
}

