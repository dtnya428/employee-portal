using EmployeePortal.Models;

namespace EmployeePortal.Repositories
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task HardDelete(Guid id);
        Task SoftDelete(Guid id);
        Task SaveChangesAsync();
    } 
}
