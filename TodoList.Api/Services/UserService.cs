using TodoList.Api.Entities;
using TodoList.Api.Repositories;
using TodoList.Lib.DTO;

namespace TodoList.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repoUserRepository;
        public UserService(IUserRepository userRepository)
        {
            _repoUserRepository = userRepository;
        }
        public async Task AddUserAsync(UserDTO userDto)
        {
            var user = new User()
            {
                Id = userDto.Id,
                UserName = userDto.UserName,
                Email = userDto.Email,
            };
            await _repoUserRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var userDel = await _repoUserRepository.GetByIdAsync(id);
            if (userDel != null)
            {
                await _repoUserRepository.DeleteAsync(userDel);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _repoUserRepository.GetAllAsync();
            var userDTOs = new List<UserDTO>();

            foreach (var item in users)
            {
                var userDTO = new UserDTO()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    Email = item.Email
                };
                userDTOs.Add(userDTO);
            }

            return userDTOs;
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _repoUserRepository.GetByIdAsync(id);
            var userDTO = new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
            };

            return userDTO;
        }

        public async Task UpdateUserAsync(UserDTO userDto)
        {
            var user = new User()
            {
                Id = userDto.Id,
                UserName= userDto.UserName,
                Email = userDto.Email,
            };

            await _repoUserRepository.UpdateAsync(user);
        }
    }
}
