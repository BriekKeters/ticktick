using System.Linq.Expressions;
using TickTick.Models;

namespace TickTick.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();

        //var Q = await repo.GetAsync(p=> p.IsDeleted == false;)
        //var Q = await repo.GetAsync(p=> p.Id == id;)
        //var Q = await repo.GetAsync(p=> p.FirstName == "Kevin" && p.IsDeleted == false)
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> SaveAsync();
    }
}

