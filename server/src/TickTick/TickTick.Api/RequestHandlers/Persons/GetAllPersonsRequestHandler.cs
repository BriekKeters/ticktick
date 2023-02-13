using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TickTick.Api.Dtos;
using TickTick.Models;
using TickTick.Repositories.Base;

namespace TickTick.Api.RequestHandlers.Persons
{

	public class GetAllPersonsRequest : QueryBase<IEnumerable<PersonDto>> { }

	public class GetAllPersonsRequestHandler:IRequestHandler<GetAllPersonsRequest, IEnumerable<PersonDto>>
	{
        private IRepository<Person> PersonRepo;

        public GetAllPersonsRequestHandler(IRepository<Person> personRepo)
		{
			this.PersonRepo = personRepo;
		}

        public async Task<IEnumerable<PersonDto>> Handle(GetAllPersonsRequest request, CancellationToken cancellationToken)
        {
            var people = await PersonRepo.GetAllAsync(p=>p.IsDeleted == false);
            var dto = new List<PersonDto>();
            foreach(var person in people)
            {
                dto.Add(person.ConvertToDto());
            }
            return dto;
        }
    }
}

