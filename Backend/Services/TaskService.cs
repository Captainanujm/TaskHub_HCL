using TaskHub.Repositories;
using TaskHub.Models;
using TaskHub.DTOs;
namespace TaskHub.Services
{
    public class TaskService:ITaskService
    {
        private readonly ITaskRepo _taskRepo;
        public TaskService(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }
        public async Task<IEnumerable<TaskDTO>> GetAll()
        {
            var tasks= await _taskRepo.GetAllAsync();
            return tasks.Select(t => new TaskDTO
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Status = t.Status ?? "Pending",
            });
        }
        public async Task<TaskDTO?> GetById(int id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null) return null;
            return new TaskDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status ?? "Pending",
            };
        }
        public async Task<TaskDTO?> UpdateTask(TaskDTO taskDto)
        {
            var task = new Todotask
            {
                Id = taskDto.Id,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
            };
            var updatedTask = await _taskRepo.UpdateTaskAsync(task);
            if (updatedTask == null)
            {
                return null;
            }

            return new TaskDTO
            {
                Id = updatedTask.Id,
                Title = updatedTask.Title,
                Description = updatedTask.Description,
                Status = updatedTask.Status ?? "Pending",
            };
        }
        public async Task<TaskDTO> CreateTask(TaskDTO taskDto)
        {
            var task = new Todotask
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
            };
            var createdTask = await _taskRepo.CreateTaskAsync(task);
            return new TaskDTO
            {
                Id = createdTask.Id,
                Title = createdTask.Title,
                Description = createdTask.Description,
                Status = createdTask.Status ?? "Pending",
            };
        }
        public async Task<TaskDTO?> DeleteTask(int id)
        {
            var deletedTask = await GetById(id);
            if (deletedTask == null)
            {
                return null;
            }

            await _taskRepo.DeleteTaskAsync(id);
            return deletedTask;
        }
    }
}
