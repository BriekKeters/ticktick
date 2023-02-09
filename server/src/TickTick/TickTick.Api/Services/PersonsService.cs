﻿using System;
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
            person.update(dto);
            return person.ConvertToDto();
        }
        public PersonDto AddLocation(PersonDto dto, LocationDto loc)
        {
            Person person = new Person(
                dto.FirstName,
                dto.LastName,
                dto.Email
                );
            person.AddLocation(loc);
            person.update(dto);
            return person.ConvertToDto();
        }
    }
}

