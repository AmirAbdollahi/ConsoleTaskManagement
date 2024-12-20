using ConsoleTaskManagement.Application.UserCases;
using ConsoleTaskManagement.Infrastructure.Persistance;

Console.WriteLine("Hello, World!");

var taskRepository = new InMemoryTaskRepository();
var addTaskUseCase = new AddTaskUseCase(taskRepository);

while (true)
{
    Console.Clear();
    Console.WriteLine("Task Manager");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Delete Task");
    Console.WriteLine("4. Exit");

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.Write("Enter Title: ");
            var title = Console.ReadLine();
            Console.Write("Enter Description: ");
            var description = Console.ReadLine();
            Console.Write("Enter Due Date (yyyy-MM-dd): ");
            var dueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Priority (Low/Medium/High): ");
            var priority = Console.ReadLine();

            addTaskUseCase.Execute(title, description, dueDate, priority);
            Console.WriteLine("Task added successfully!");
            Console.ReadKey();
            break;

        case "2":
            Console.Clear();
            foreach (var task in taskRepository.GetAllTasks())
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate}, Priority: {task.Priority}");
            }
            Console.ReadKey();
            break;

        case "3":
            Console.Write("Enter Task ID to Delete: ");
            var id = Guid.Parse(Console.ReadLine());
            taskRepository.DeleteTask(id);
            Console.WriteLine("Task deleted successfully!");
            Console.ReadKey();
            break;

        case "4":
            return;
    }
}