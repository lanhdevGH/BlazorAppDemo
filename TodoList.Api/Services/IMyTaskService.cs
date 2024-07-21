using TodoList.Lib.DTO;

namespace TodoList.Api.Services
{
    public interface IMyTaskService
    {
        Task<IEnumerable<MyTaskDTO>> GetAllMyTasksAsync();
        Task<MyTaskDTO> GetMyTaskByIdAsync(Guid id);
        Task AddMyTaskAsync(MyTaskDTO myTaskDTO);
        Task UpdateMyTaskAsync(MyTaskDTO myTaskDTO);
        Task DeleteMyTaskAsync(Guid id);
    }
}
