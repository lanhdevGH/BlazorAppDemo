
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Api.Entities;

namespace TodoList.Api.Repositories
{
    public interface IMyTaskRepository 
    {
        Task<MyTask> GetByIdAsync(Guid id);
        Task<IEnumerable<MyTask>> GetAllAsync();
        Task<IEnumerable<MyTask>> FindAsync(Expression<Func<MyTask, bool>> predicate);
        Task AddAsync(MyTask entity);
        Task UpdateAsync(MyTask entity);
        Task DeleteAsync(MyTask entity);
    }
}
            