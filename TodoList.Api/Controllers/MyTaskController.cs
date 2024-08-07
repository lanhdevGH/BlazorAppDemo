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
        public async Task<ActionResult<IEnumerable<MyTaskDTO>>> GetAllTask([FromQuery] TaskSearch taskSearch)
        {
            var listTasks = await _myTaskService.GetAllMyTasksAsync(taskSearch);
            
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
        public async Task<ActionResult> CreateTask([FromBody]TaskCreateRequest instance)
        {
            await _myTaskService.AddMyTaskAsync(instance);
            return CreatedAtAction(nameof(GetTaskById), new {id = instance.Id}, instance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskUpdateRequest instance)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var taskUpd = await _myTaskService.GetMyTaskByIdAsync(id);

            if (taskUpd == null)
            {
                return NotFound($"{id} is not found");
            }

            taskUpd.Name = instance.Name;
            taskUpd.Description = instance.Description;
            taskUpd.Status = instance.Status;
            taskUpd.Priority = instance.Priority;
            taskUpd.UpdatedDate = DateTime.Now;

            await _myTaskService.UpdateMyTaskAsync(taskUpd);
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
