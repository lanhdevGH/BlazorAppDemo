
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;
using TodoList.Api.Data;
using System.Linq.Expressions;

namespace TodoList.Api.Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TodoListDb _context;
        public RoleRepository(TodoListDb dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(Role entity)
        {
            await _context.Set<Role>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Role entity)
        {
            _context.Set<Role>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> FindAsync(Expression<Func<Role, bool>> predicate)
        {
            return await _context.Set<Role>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Set<Role>().ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Role entity)
        {
            _context.Set<Role>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
            