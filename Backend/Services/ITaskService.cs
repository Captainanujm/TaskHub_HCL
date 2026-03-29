using TaskHub.Models;
using TaskHub.DTOs;
namespace TaskHub.Services
{
    public interface ITaskService
    {
        public Task<IEnumerable<TaskDTO>> GetAll();
       public Task<TaskDTO> GetById(int id);
        public Task<TaskDTO> UpdateTask(TaskDTO task);
        public Task<TaskDTO> CreateTask(TaskDTO task);
        public Task<TaskDTO?> DeleteTask(int id);

    }
}
