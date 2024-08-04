using System.Net.Http.Json;
using TodoList.Lib.DTO;

namespace TodoListWasm.Services
{
    public class TaskClientService : ITaskClientService
    {
        private readonly HttpClient _httpClient;

        public TaskClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public async Task<bool> CreateNewTask(TaskCreateRequest taskCreate)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/MyTask", taskCreate);
            return result.IsSuccessStatusCode;
        }

        public async Task<MyTaskDTO?> GetTask(string taskId)
        {
            var taskNewId = Guid.Parse(taskId);
            var result = await _httpClient.GetFromJsonAsync<MyTaskDTO>($"/api/MyTask/{taskNewId}");
            return result;
        }

        public async Task<List<MyTaskDTO>?> GetTaskList(TaskSearch taskSearch)
        {
            string url = $"/api/MyTask?name={taskSearch.Name}&assigneeID={taskSearch.AssigneeID}&priority={taskSearch.Priority}&status={taskSearch.Status}";
            var result = await _httpClient.GetFromJsonAsync<List<MyTaskDTO>>(url);
            return result;
        }


    }
}
