using ConsoleTaskManagement.Domain.Interfaces;
using Task = ConsoleTaskManagement.Domain.Entites.Task;

namespace ConsoleTaskManagement.Infrastructure.Persistance
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks = new();

        public void AddTask(Task task) => _tasks.Add(task);
        public IEnumerable<Task> GetAllTasks() => _tasks;
        public Task GetTaskById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
        public void DeleteTask(Guid id) => _tasks.RemoveAll(t => t.Id == id);
    }
}
