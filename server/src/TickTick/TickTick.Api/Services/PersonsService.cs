using System;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Api.Dtos;

namespace TickTick.Api
{
    public class PersonsService : IPersonsService
    {
        public PersonsService()
        {
        }

        public void DeletePerson(Guid id)
        {
            //TODO databaze shizzle
        }
        public PersonDto AddPerson(AddPersonDto dto)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email
                );
            person.CreatePublicId();
            return person.ConvertToDto();
        }
        public PersonDto UpdatePerson(Guid id, PersonDto dto)
        {
            //TODO databaze shizzle
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email
                );
            person.update(dto.FirstName, dto.LastName,dto.MiddleName,dto.DateOfBirth,dto.Email);
            return person.ConvertToDto();
        }
    }
}

