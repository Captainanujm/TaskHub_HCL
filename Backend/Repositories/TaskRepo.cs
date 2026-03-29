using Microsoft.EntityFrameworkCore;
using TaskHub.Models;
namespace TaskHub.Repositories
{
    public class TaskRepo:ITaskRepo
    {
        private readonly TaskdbContext _context;
        public TaskRepo(TaskdbContext context)
        {
            //injecting the dependency
            _context = context;
        }
        public async Task<IEnumerable<Todotask>> GetAllAsync()
        {
            var tasks = await _context.Todotasks.ToListAsync();
            return tasks;
        }
        public async Task<Todotask?> GetByIdAsync(int id)
        {
            var task = await _context.Todotasks.FindAsync(id);
            return task;
        }
        public async Task<Todotask?> UpdateTaskAsync(Todotask task)
        {
            var existingTask = await _context.Todotasks.FindAsync(task.Id);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;

            await _context.SaveChangesAsync();
            return existingTask;
        }
        public async Task<Todotask> CreateTaskAsync(Todotask task)
        {
            _context.Todotasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Todotasks.FindAsync(id);
            if (task != null)
            {
                _context.Todotasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
