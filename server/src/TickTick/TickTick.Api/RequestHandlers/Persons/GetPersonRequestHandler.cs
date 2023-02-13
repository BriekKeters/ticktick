using System;
using TickTick.Api.Dtos;

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
	public class GetPersonRequestHandler
	{
		public GetPersonRequestHandler()
		{
		}
	}
}

