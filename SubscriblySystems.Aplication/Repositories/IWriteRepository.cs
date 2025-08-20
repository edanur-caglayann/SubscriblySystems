using subscriblySystem.Domain.Models;

namespace SubscriblySystems.Aplication.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T: BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddMultipleAsync(List<T> entities);
    bool Update(T entity); // senkron guncelleme
    Task<bool> DeleteAsync(Guid id); 
    bool Delete(T entity);
    bool DeleteMultiple(IEnumerable<T> entities);
    Task<int> SaveAsync(); // Ef core'un SaveChangesAsync fonk cagirir
    //yapilan degisiklikleri db yazar
    
    
}