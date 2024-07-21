using TodoList.Api.Entities;
using TodoList.Api.Repositories;
using TodoList.Lib.DTO;

namespace TodoList.Api.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IMyTaskRepository _repoMyTaskRepository;
        public MyTaskService(IMyTaskRepository MyTaskRepository)
        {
            _repoMyTaskRepository = MyTaskRepository;
        }

        public async Task AddMyTaskAsync(MyTaskDTO myTaskDTO)
        {
            var task = new MyTask()
            {
                Id = myTaskDTO.Id,
                Name = myTaskDTO.Name,
                Description = myTaskDTO.Description,
                AssigneeID = myTaskDTO.AssigneeID,
                CreatedDate = myTaskDTO.CreatedDate,
                UpdatedDate = myTaskDTO.UpdatedDate,
                Priority = myTaskDTO.Priority,
                Status = myTaskDTO.Status
            };

            await _repoMyTaskRepository.AddAsync(task);
        }

        public async Task DeleteMyTaskAsync(Guid id)
        {
            var taskDel = await _repoMyTaskRepository.GetByIdAsync(id);
            if (taskDel != null)
            {
                await _repoMyTaskRepository.DeleteAsync(taskDel);
            }
        }

        public async Task<IEnumerable<MyTaskDTO>> GetAllMyTasksAsync()
        {
            var tasks = await _repoMyTaskRepository.GetAllAsync();
            var taskDTOs = new List<MyTaskDTO>();

            foreach (var task in tasks)
            {
                var taskDTO = new MyTaskDTO()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Description = task.Description,
                    AssigneeID = task.AssigneeID,
                    AssigneeName = task.Assignee?.UserName,
                    CreatedDate = task.CreatedDate,
                    UpdatedDate = task.UpdatedDate,
                    Priority = task.Priority,
                    Status = task.Status
                };
                taskDTOs.Add(taskDTO);
            }
            return taskDTOs;
        }

        public async Task<MyTaskDTO> GetMyTaskByIdAsync(Guid id)
        {
            var task = await _repoMyTaskRepository.GetByIdAsync(id);
            var taskDTO = new MyTaskDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                AssigneeID = task.AssigneeID,
                CreatedDate = task.CreatedDate,
                UpdatedDate = task.UpdatedDate,
                Priority = task.Priority,
                Status = task.Status
            };

            return taskDTO;
        }

        public async Task UpdateMyTaskAsync(MyTaskDTO myTaskDTO)
        {
            var task = new MyTask()
            {
                Id = myTaskDTO.Id,
                Name = myTaskDTO.Name,
                Description = myTaskDTO.Description,
                AssigneeID = myTaskDTO.AssigneeID,
                CreatedDate = myTaskDTO.CreatedDate,
                UpdatedDate = myTaskDTO.UpdatedDate,
                Priority = myTaskDTO.Priority,
                Status = myTaskDTO.Status,
            };
            await _repoMyTaskRepository.UpdateAsync(task);
        }
    }
}
