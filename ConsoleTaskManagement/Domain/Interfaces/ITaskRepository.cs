using Task = ConsoleTaskManagement.Domain.Entites.Task;

namespace ConsoleTaskManagement.Domain.Interfaces
{
    public interface ITaskRepository
    {
        void AddTask(Task task);
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(Guid id);
        void DeleteTask(Guid id);
    }
}
