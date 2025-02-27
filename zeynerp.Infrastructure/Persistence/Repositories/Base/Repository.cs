using Microsoft.EntityFrameworkCore;
using zeynerp.Core.Domain.Entities.Base;
using zeynerp.Core.Interfaces.Repositories.Base;
using zeynerp.Infrastructure.Persistence.Data;

namespace zeynerp.Infrastructure.Persistence.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
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

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }        

        public void Update(T entity) =>
            _context.Entry(entity).State = EntityState.Modified;
    }
}