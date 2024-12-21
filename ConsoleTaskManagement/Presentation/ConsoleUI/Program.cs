using ConsoleTaskManagement.Application.UserCases;
using ConsoleTaskManagement.Infrastructure.Persistance;
using System.Text;
using Task = ConsoleTaskManagement.Domain.Entites.Task;

class Program
{
    static void Main()
    {
        var taskRepository = new InMemoryTaskRepository();
        var addTaskUseCase = new AddTaskUseCase(taskRepository);
        var editTaskUseCase = new EditTaskUseCase(taskRepository);
        var deleteTaskUseCase = new DeleteTaskUseCase(taskRepository);

        ShowMainMenu(
            taskRepository: taskRepository,
            addTaskUseCase: addTaskUseCase,
            editTaskUseCase: editTaskUseCase,
            deleteTaskUseCase: deleteTaskUseCase);
    }

    private static void MainMenuPrompt()
    {
        Console.WriteLine("Press any key to show main menu.");
        Console.ReadKey();
        Console.Clear();
    }

    private static void ShowMainMenu(
        InMemoryTaskRepository taskRepository, 
        AddTaskUseCase addTaskUseCase, 
        EditTaskUseCase editTaskUseCase,
        DeleteTaskUseCase deleteTaskUseCase)
    {
        while (true)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            var choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    AddTask(addTaskUseCase);
                    break;

                case "2":
                    ViewTasks(taskRepository);
                    break;

                case "3":
                    EditTask(editTaskUseCase, taskRepository);
                    break;

                case "4":
                    DeleteTask(deleteTaskUseCase);
                    break;

                case "5":
                    return;
            }
        }
    }

    private static void DeleteTask(DeleteTaskUseCase deleteTaskUseCase)
    {
        try
        {
            Console.Write("Enter Task ID to Delete: ");
            var id = Guid.Parse(Console.ReadLine());
            deleteTaskUseCase.Execute(id);
            Console.WriteLine("Task deleted successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            MainMenuPrompt();
        }
    }

    private static void ViewTasks(InMemoryTaskRepository taskRepository)
    {
        try
        {
            Console.WriteLine(GetTasksInTableFormat(taskRepository.GetAllTasks()));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            MainMenuPrompt();
        }
    }

    private static void AddTask(AddTaskUseCase addTaskUseCase)
    {
        try
        {
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
        }
        catch (Exception ex) 
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            MainMenuPrompt();
        }
    }

    static void EditTask(EditTaskUseCase editTaskUseCase, InMemoryTaskRepository taskRepository)
    {
        try
        {
            Console.Write("Enter Task ID to Edit: ");
            var id = Guid.Parse(Console.ReadLine());

            var task = taskRepository.GetTaskById(id);
            if (task == null)
            {
                throw new ArgumentNullException(paramName: nameof(task));
            }

            Console.WriteLine($"Current Title: {task.Title}");
            Console.Write("Enter New Title: ");
            var title = Console.ReadLine();

            Console.WriteLine($"Current Description: {task.Description}");
            Console.Write("Enter New Description: ");
            var description = Console.ReadLine();

            Console.WriteLine($"Current Due Date: {task.DueDate:yyyy-MM-dd}");
            Console.Write("Enter New Due Date (yyyy-MM-dd): ");
            var dueDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Current Priority: {task.Priority}");
            Console.Write("Enter New Priority (Low/Medium/High): ");
            var priority = Console.ReadLine();

            editTaskUseCase.Execute(
                taskId: id,
                title: title,
                description: description,
                dueDate: dueDate,
                priority: priority);
            Console.WriteLine("Task updated successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            MainMenuPrompt();
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