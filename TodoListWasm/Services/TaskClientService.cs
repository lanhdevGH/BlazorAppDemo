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

        public async Task<MyTaskDTO?> GetTask(string taskId)
        {
            var taskNewId = Guid.Parse(taskId);
            var result = await _httpClient.GetFromJsonAsync<MyTaskDTO>($"/api/MyTask/{taskNewId}");
            return result;
        }

        public async Task<List<MyTaskDTO>?> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MyTaskDTO>>("/api/MyTask");
            return result;
        }
    }
}
