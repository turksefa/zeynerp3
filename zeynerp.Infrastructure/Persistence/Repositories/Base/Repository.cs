using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Domain.Entities.Base;
using zeynerp.Core.Repositories.Base;
using zeynerp.Infrastructure.Persistence.Data;

namespace zeynerp.Infrastructure.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) =>
            await _dbSet.FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }        

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}