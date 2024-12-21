using ConsoleTaskManagement.Application.UserCases;
using ConsoleTaskManagement.Infrastructure.Persistance;
using System.Text;
using Task = ConsoleTaskManagement.Domain.Entites.Task;

class Program
{
    static void Main()
    {

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
                    Console.WriteLine(GetTasksInTableFormat(taskRepository.GetAllTasks()));
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




    }

    static string GetTasksInTableFormat(IEnumerable<Task> tasks)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(string.Format("{0,-40} {1,-20} {2, -20} {3,-15} {4,-15}", "ID", "Task Title", "Description", "Priority", "Due Date"));
        sb.AppendLine(new string('-', 115));

        foreach (var task in tasks)
        {
            sb.AppendLine(
                string.Format("{0,-40} {1,-20} {2, -20} {3,-15} {4,-15}",
                task.Id,
                task.Title,
                task.Description,
                task.Priority,
                task.DueDate.ToShortDateString()));
        }

        return sb.ToString();
    }
}