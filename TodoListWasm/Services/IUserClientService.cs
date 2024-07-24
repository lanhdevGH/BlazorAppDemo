using TodoList.Lib.DTO;

namespace TodoListWasm.Services
{
    public interface IUserClientService
    {
        public Task<List<UserDTO>?> GetAllUser();

        public Task<UserDTO?> GetUserById(string userId);
    }
}
