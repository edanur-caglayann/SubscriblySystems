using Microsoft.EntityFrameworkCore;
using subscriblySystem.Domain.Models;

namespace SubscriblySystems.Aplication.Repositories;

public interface IRepository<T> where T: BaseEntity
{
    DbSet<T> Table { get; }

}