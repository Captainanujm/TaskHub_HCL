using TaskHub.Models;

namespace TaskHub.Repositories
{
    public interface ITaskRepo
    {
        public Task<IEnumerable<Todotask>> GetAllAsync();
        public Task<Todotask?> GetByIdAsync(int id);
        public Task<Todotask> UpdateTaskAsync(Todotask task);
        public Task<Todotask> CreateTaskAsync(Todotask task);
        public Task DeleteTaskAsync(int id);

    }
}
