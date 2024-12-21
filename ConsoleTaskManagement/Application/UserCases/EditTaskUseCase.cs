using ConsoleTaskManagement.Domain.Entites;
using ConsoleTaskManagement.Domain.Interfaces;

namespace ConsoleTaskManagement.Application.UserCases
{
    public class EditTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public EditTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(Guid taskId, string title, string description, DateTime dueDate, string priority)
        {
            var task = _taskRepository.GetTaskById(taskId);

            if (task == null)
                throw new ArgumentException($"Task with ID {taskId} not found.");

            var priorityLevel = Enum.Parse<PriorityLevel>(priority, true);
            task.Update(title, description, dueDate, priorityLevel);
        }
    }
}
