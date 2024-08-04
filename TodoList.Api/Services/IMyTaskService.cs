using TodoList.Lib.DTO;

namespace TodoList.Api.Services
{
    public interface IMyTaskService
    {
        Task<IEnumerable<MyTaskDTO>> GetAllMyTasksAsync(TaskSearch task);
        Task<MyTaskDTO> GetMyTaskByIdAsync(Guid id);
        Task AddMyTaskAsync(TaskCreateRequest myTaskDTO);
        Task UpdateMyTaskAsync(MyTaskDTO myTaskDTO);
        Task DeleteMyTaskAsync(Guid id);
    }
}
