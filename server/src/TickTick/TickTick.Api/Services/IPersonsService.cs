using TickTick.Api.Dtos.Persons;
using TickTick.Api.Dtos;
using TickTick.Repositories.Base;
using TickTick.Models;

namespace TickTick.Api
{
    public interface IPersonsService
    {
        void DeletePerson(Person p);
        PersonDto AddPerson(AddPersonDto dto);
        PersonDto UpdatePerson(Person p, PersonDto dto);
    }
}