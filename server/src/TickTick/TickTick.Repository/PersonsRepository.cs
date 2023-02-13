using System;
using TickTick.Data;
using TickTick.Models;

namespace TickTick.Repositories
{
    //wanneer specifieke repo methodes wilt bovenop de base repository
    //dit 
	public class PersonsRepository :Repository<Person>
	{
        public PersonsRepository(TickTickDbContext ctx) : base(ctx)
        {
        }
    }
    //of deze
    public static class PersonRepositoryExtensions
    {
        public static IEnumerable<Person> GetDeadPeople(this Repository<Person> repository)
        {
            return repository.GetAll();
        }
    }
}

