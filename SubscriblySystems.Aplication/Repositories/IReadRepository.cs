using System.Linq.Expressions;
using subscriblySystem.Domain.Models;

namespace SubscriblySystems.Aplication.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
    Task<T> GetByIdAsync(Guid id, bool tracking = true);
}