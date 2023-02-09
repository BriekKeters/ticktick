using TickTick.Api.Dtos.Persons;
using TickTick.Models.Dtos;

namespace TickTick.Api
{
    public interface IPersonsService
    {
        void DeletePerson(Guid id);
        PersonDto AddPersonDto(AddPersonDto dto);
    }
}