
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Api.Entities;

namespace TodoList.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate);
        Task AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(User entity);
    }
}
            