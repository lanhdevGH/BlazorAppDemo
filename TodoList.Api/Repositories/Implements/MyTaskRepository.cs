
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;
using TodoList.Api.Data;
using System.Linq.Expressions;

namespace TodoList.Api.Repositories.Implements
{
    public class MyTaskRepository : IMyTaskRepository
    {
        private readonly TodoListDb _context;
        public MyTaskRepository(TodoListDb dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(MyTask entity)
        {
            await _context.Set<MyTask>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MyTask entity)
        {
            _context.Set<MyTask>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MyTask>> FindAsync(Expression<Func<MyTask, bool>> predicate)
        {
            return await _context.Set<MyTask>().Include(x => x.Assignee).Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<MyTask>> GetAllAsync()
        {
            return await _context.Set<MyTask>().Include(x => x.Assignee).ToListAsync() ;
        }

        public async Task<MyTask?> GetByIdAsync(Guid id)
        {
            return await _context.Set<MyTask>().Include(x => x.Assignee).FirstOrDefaultAsync(x => x.Id == id) ;
        }

        public async Task UpdateAsync(MyTask entity)
        {
            _context.Set<MyTask>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
            