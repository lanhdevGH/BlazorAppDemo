using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Entities;
using TodoList.Api.Enums;

namespace TodoList.Api.Repositories.Impl
{
    public class MyTaskRepository : Repository<MyTask>, IMyTaskRepository
    {
        public MyTaskRepository(TodoListDb dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<MyTask>> GetTasksByPriorityAsync(Priority priority)
        {
            return await _dbContext.MyTasks.Where(item => item.Priority == priority).ToListAsync() ;
        }
    }
}
