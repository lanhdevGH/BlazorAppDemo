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

        public async Task AddMyTaskAsync(TaskCreateRequest myTaskDTO)
        {
            var task = new MyTask()
            {
                Id = myTaskDTO.Id,
                Name = myTaskDTO.TaskName,
                Description = myTaskDTO.TaskDescription,
                AssigneeID = null,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
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

        public async Task<IEnumerable<MyTaskDTO>> GetAllMyTasksAsync(TaskSearch taskSearch)
        {
            var tasks = await _repoMyTaskRepository.GetAllAsync();
            var taskDTOs = new List<MyTaskDTO>();

            if (taskSearch != null)
            {
                tasks = tasks.Where(t => string.IsNullOrEmpty(taskSearch.Name) || t.Name.Contains(taskSearch.Name))
                            .Where(t => !taskSearch.AssigneeID.HasValue || t.AssigneeID == taskSearch.AssigneeID)
                            .Where(t => !taskSearch.Priority.HasValue || t.Priority == taskSearch.Priority)
                            .Where(t => !taskSearch.Status.HasValue || t.Status == taskSearch.Status)
                            .ToList();
            }
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
            return taskDTOs.OrderByDescending(x => x.CreatedDate);
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
            var taskUpd = await _repoMyTaskRepository.GetByIdAsync(myTaskDTO.Id);

            taskUpd.Id = myTaskDTO.Id;
            taskUpd.Name = myTaskDTO.Name;
            taskUpd.Description = myTaskDTO.Description;
            taskUpd.AssigneeID = myTaskDTO.AssigneeID;
            taskUpd.CreatedDate = myTaskDTO.CreatedDate;
            taskUpd.UpdatedDate = myTaskDTO.UpdatedDate;
            taskUpd.Priority = myTaskDTO.Priority;
            taskUpd.Status = myTaskDTO.Status;
            await _repoMyTaskRepository.UpdateAsync(taskUpd);
        }
    }
}
