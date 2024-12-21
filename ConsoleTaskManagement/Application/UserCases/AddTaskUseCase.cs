using ConsoleTaskManagement.Domain.Entites;
using ConsoleTaskManagement.Domain.Interfaces;
using Task = ConsoleTaskManagement.Domain.Entites.Task;

namespace ConsoleTaskManagement.Application.UserCases
{
    internal class AddTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public AddTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(string title, string description, DateTime dueDate, string priority)
        {
            var priorityLevel = Enum.Parse<PriorityLevel>(priority, true);
            var task = new Task(title, description, dueDate, priorityLevel);
            _taskRepository.AddTask(task);
        }
    }
}
