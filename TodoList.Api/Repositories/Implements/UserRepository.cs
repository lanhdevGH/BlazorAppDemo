
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;
using TodoList.Api.Data;
using System.Linq.Expressions;

namespace TodoList.Api.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDb _context;
        public UserRepository(TodoListDb dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            _context.Set<User>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Set<User>().ToListAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Set<User>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
            