using EmployeePortal.DataContext;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel 
    {
        private readonly EmployeeContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EmployeeContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbSet.Where(e => !e.IsDeleted);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            T? result = await _dbSet.FindAsync(id);
            return (result != null && !result.IsDeleted) ? result : null;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task HardDelete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SoftDelete(Guid id)
        {
            T? entity = await _dbSet.FindAsync(id);
            if (entity != null && !entity.IsDeleted)
            {
                entity.IsDeleted = true;
                entity.UpdatedDate = DateTime.Now;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

