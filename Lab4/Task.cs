using System;

public class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "Не начато";
    public string Responsible { get; set; }
    public DateTime DueDate { get; set; }

    public Task(string name, string description, string responsible, DateTime dueDate)
    {
        Name = name;
        Description = description;
        Responsible = responsible;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        return $"{Name} (Ответственный: {Responsible}, Статус: {Status}, Срок: {DueDate.ToShortDateString()})";
    }
}
