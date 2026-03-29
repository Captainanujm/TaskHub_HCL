using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskHub.Services;
using TaskHub.DTOs;
namespace TaskHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.GetAll();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDTO taskDto)
        {
            if (id != taskDto.Id)
            {
                return BadRequest("Route id and payload id must match.");
            }

            var updatedTask = await _taskService.UpdateTask(taskDto);
            if (updatedTask == null)
            {
                return NotFound();
            }

            return Ok(updatedTask);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDTO taskDto)
        {
            var createdTask = await _taskService.CreateTask(taskDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deletedTask = await _taskService.DeleteTask(id);
            if (deletedTask == null) return NotFound();
            return Ok(deletedTask);

        }
    }
}
