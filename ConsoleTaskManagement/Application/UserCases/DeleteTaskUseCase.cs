using ConsoleTaskManagement.Domain.Entites;
using ConsoleTaskManagement.Domain.Interfaces;

namespace ConsoleTaskManagement.Application.UserCases
{
    public class DeleteTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public DeleteTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void Execute(Guid taskId)
        {
            var task = _taskRepository.GetTaskById(taskId);

            if (task == null)
                throw new ArgumentException($"Task with ID {taskId} not found.");

            _taskRepository.DeleteTask(taskId);
        }
    }
}
