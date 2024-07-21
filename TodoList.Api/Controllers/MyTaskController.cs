using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Entities;
using TodoList.Api.Services;
using TodoList.Lib.DTO;

namespace TodoList.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyTaskController : Controller
    {
        private readonly IMyTaskService _myTaskService;

        public MyTaskController(IMyTaskService myTaskService)
        {
            _myTaskService = myTaskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MyTaskDTO>>> GetAllTask()
        {
            var listTasks = await _myTaskService.GetAllMyTasksAsync();
            
            return Ok(listTasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MyTaskDTO>> GetTaskById(Guid id)
        {
            var instance = await _myTaskService.GetMyTaskByIdAsync(id);
            if (instance == null)
            {
                return NotFound($"{id} is not found");
            }
            return Ok(instance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(MyTaskDTO instance)
        {
            await _myTaskService.AddMyTaskAsync(instance);
            return CreatedAtAction(nameof(GetTaskById), new {id = instance.Id}, instance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, MyTaskDTO instance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != instance.Id)
            {
                return BadRequest();
            }

            await _myTaskService.UpdateMyTaskAsync(instance);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _myTaskService.DeleteMyTaskAsync(id);
            return NoContent();
        }
    }
}
