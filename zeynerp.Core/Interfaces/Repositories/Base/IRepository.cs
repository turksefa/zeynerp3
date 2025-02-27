using zeynerp.Core.Domain.Entities.Base;

namespace zeynerp.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}