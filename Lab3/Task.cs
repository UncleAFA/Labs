// Определение класса для задачи
class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string ResponsibleEcologist { get; set; }
    public DateTime Deadline { get; set; }

    public Task(string title, string description, string responsibleEcologist, DateTime deadline)
    {
        Title = title;
        Description = description;
        Status = "Не начато"; // Начальный статус
        ResponsibleEcologist = responsibleEcologist;
        Deadline = deadline;
    }

    public void DisplayTask()
    {
        Console.WriteLine($"Название задачи: {Title}");
        Console.WriteLine($"Описание: {Description}");
        Console.WriteLine($"Ответственный эколог: {ResponsibleEcologist}");
        Console.WriteLine($"Статус: {Status}");
        Console.WriteLine($"Срок выполнения: {Deadline.ToShortDateString()}\n");
    }
}