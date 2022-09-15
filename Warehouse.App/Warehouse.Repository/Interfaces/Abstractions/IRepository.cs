namespace Warehouse.Repository.Interfaces.Abstractions;

public interface IRepository<T>
{
    Task<T> GetAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> RemoveAsync(Guid id);
}
