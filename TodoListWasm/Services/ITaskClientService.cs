using TodoList.Lib.DTO;

namespace TodoListWasm.Services
{
    public interface ITaskClientService
    {
        public Task<List<MyTaskDTO>?> GetTaskList();

        public Task<MyTaskDTO?> GetTask(string taskId);
    }
}
