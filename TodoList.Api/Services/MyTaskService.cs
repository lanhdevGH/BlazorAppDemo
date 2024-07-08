using TodoList.Api.Entities;
using TodoList.Api.Enums;
using TodoList.Api.Repositories.Impl;

namespace TodoList.Api.Services
{
    public class MyTaskService
    {
        private readonly MyTaskRepository _myTaskRepository;
        public MyTaskService(MyTaskRepository myTaskRepository)
        {
            _myTaskRepository = myTaskRepository;
        }

        public async Task<IEnumerable<MyTask>> GetAllTasksAsync()
        {
            return await _myTaskRepository.GetAllAsync();
        }

        public async Task<MyTask> GetMyTaskAsync(Guid id)
        {
            return await _myTaskRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MyTask>> GetMyTasksByPriority(Priority priority)
        {
            return await _myTaskRepository.GetTasksByPriorityAsync(priority);
        }

        public async Task AddMyTaskAsync(MyTask task)
        {
            await _myTaskRepository.AddAsync(task);
        }

        public async Task UpdateMyTaskAsync(MyTask myTask)
        {
            await _myTaskRepository.UpdateAsync(myTask);
        }

        public async Task DeleteMyTaskAsync(MyTask myTask)
        {
            var taskDelete = await _myTaskRepository.GetByIdAsync(myTask.Id);
            if (taskDelete != null)
            {
                await _myTaskRepository.DeleteAsync(taskDelete);
            }
        }
    }
}
