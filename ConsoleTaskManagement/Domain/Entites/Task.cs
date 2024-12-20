namespace ConsoleTaskManagement.Domain.Entites
{
    public class Task
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime DueDate { get; private set; }
        public PriorityLevel Priority { get; private set; }

        public Task(string title, string description, DateTime dueDate, PriorityLevel priority)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Task title cannot be empty.");

            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}
