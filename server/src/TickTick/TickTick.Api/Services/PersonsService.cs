using System;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Models.Dtos;

namespace TickTick.Api
{
    public class PersonsService : IPersonsService
    {
        public PersonsService()
        {
        }

        public void DeletePerson(Guid id)
        {

        }
        public PersonDto AddPersonDto(AddPersonDto dto)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email
                );
            person.CreatePublicId();
            return person.ConvertToDto();
        }
    }
}

