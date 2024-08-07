using TodoList.Lib.DTO;

namespace TodoListWasm.Services
{
    public interface ITaskClientService
    {
        public Task<List<MyTaskDTO>?> GetTaskList(TaskSearch taskSearch);

        public Task<MyTaskDTO?> GetTask(string taskId);

        public Task<bool> CreateNewTask(TaskCreateRequest taskCreate);
        public Task<bool> UpdateTaskByIdAsync(Guid id,TaskUpdateRequest taskCreate);
    }
}
