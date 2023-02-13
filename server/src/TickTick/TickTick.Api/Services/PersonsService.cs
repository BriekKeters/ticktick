using System;
using TickTick.Api.Dtos.Persons;
using TickTick.Models;
using TickTick.Api.Dtos;
using TickTick.Repositories.Base;

namespace TickTick.Api
{
    public class PersonsService : IPersonsService
    {
        public PersonsService()
        {
        }

        public void DeletePerson(Person p)
        {
            p.Delete();
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
        public PersonDto UpdatePerson(Person p, PersonDto dto)
        {
            p.update(dto.FirstName, dto.LastName,dto.MiddleName,dto.DateOfBirth,dto.Email);
            return p.ConvertToDto();
        }
    }
}

