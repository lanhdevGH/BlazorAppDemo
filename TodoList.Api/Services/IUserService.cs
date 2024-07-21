using TodoList.Lib.DTO;

namespace TodoList.Api.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(Guid id);
        Task AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(UserDTO userDto);
        Task DeleteUserAsync(Guid id);
    }
}
