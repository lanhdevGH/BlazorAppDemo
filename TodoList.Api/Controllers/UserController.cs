using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Services;
using TodoList.Lib.DTO;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUser()
        {
            var listUsers = await _userService.GetAllUsersAsync();
            return Ok(listUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(Guid id)
        {
            var instance = await _userService.GetUserByIdAsync(id);
            if (instance == null)
            {
                return NotFound($"{id} is not found");
            }
            return Ok(instance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(UserDTO instance)
        {
            await _userService.AddUserAsync(instance);
            return CreatedAtAction(nameof(GetUserById), new { id = instance.Id }, instance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, UserDTO instance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != instance.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(instance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}
