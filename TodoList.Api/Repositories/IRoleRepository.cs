
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Api.Entities;

namespace TodoList.Api.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetByIdAsync(Guid id);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<IEnumerable<Role>> FindAsync(Expression<Func<Role, bool>> predicate);
        Task AddAsync(Role entity);
        Task UpdateAsync(Role entity);
        Task DeleteAsync(Role entity);
    }
}
            