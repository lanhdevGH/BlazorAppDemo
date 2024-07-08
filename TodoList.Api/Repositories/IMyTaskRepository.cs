using System.Collections;
using TodoList.Api.Entities;
using TodoList.Api.Enums;

namespace TodoList.Api.Repositories
{
    public interface IMyTaskRepository : IRepository<MyTask>
    {
        Task<IEnumerable<MyTask>> GetTasksByPriorityAsync(Priority priority);
    }
}
