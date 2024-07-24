using System.Net.Http.Json;
using System.Threading.Tasks;
using TodoList.Lib.DTO;

namespace TodoListWasm.Services
{
    public class UserClientService : IUserClientService
    {
        private readonly HttpClient _httpClient;

        public UserClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserDTO>?> GetAllUser()
        {
            var listUser = await _httpClient.GetFromJsonAsync<List<UserDTO>>($"/api/user");
            return listUser;
        }

        public async Task<UserDTO?> GetUserById(string userId)
        {
            var userNewId = Guid.Parse(userId);
            var result = await _httpClient.GetFromJsonAsync<UserDTO>($"/api/user/{userNewId}");
            return result;
        }
    }
}
