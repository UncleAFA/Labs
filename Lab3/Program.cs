/// <summary>
//Добавление новой задачи — позволяет ввести название, описание, эколога и срок выполнения задачи.
//Назначение ответственного эколога — позволяет изменить ответственного за задачу эколога.
//Изменение статуса задачи — изменяет статус задачи на "Не начато", "В процессе" или "Завершено".
//Отображение задач по экологу — выводит список задач, назначенных на выбранного эколога.
//Выход — завершает программу.
/// </summary>
partial class Program
{

    // Список для хранения всех задач
    static List<Task> taskList = new List<Task>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить новую задачу");
            Console.WriteLine("2. Назначить ответственного эколога");
            Console.WriteLine("3. Изменить статус задачи");
            Console.WriteLine("4. Отобразить задачи по экологу");
            Console.WriteLine("5. Выйти");
            Console.Write("Выберите действие: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    AssignEcologist();
                    break;
                case "3":
                    ChangeStatus();
                    break;
                case "4":
                    DisplayTasksByEcologist();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.\n");
                    break;
            }
        }
    }

    // Метод для добавления новой задачи
    static void AddTask()
    {
        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine();

        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        Console.Write("Введите имя ответственного эколога: ");
        string responsibleEcologist = Console.ReadLine();

        Console.Write("Введите срок выполнения (ГГГГ-ММ-ДД): ");
        DateTime deadline;
        if (DateTime.TryParse(Console.ReadLine(), out deadline))
        {
            taskList.Add(new Task(title, description, responsibleEcologist, deadline));
            Console.WriteLine("Задача добавлена.\n");
        }
        else
        {
            Console.WriteLine("Некорректный формат даты. Задача не добавлена.\n");
        }
    }

    // Метод для назначения ответственного эколога для задачи
    static void AssignEcologist()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите название задачи для назначения ответственного: ");
        string title = Console.ReadLine();

        Task task = taskList.FirstOrDefault(t => t.Title == title);

        if (task != null)
        {
            Console.Write("Введите имя нового ответственного эколога: ");
            task.ResponsibleEcologist = Console.ReadLine();
            Console.WriteLine("Ответственный эколог назначен.\n");
        }
        else
        {
            Console.WriteLine("Задача не найдена.\n");
        }
    }

    // Метод для изменения статуса задачи
    static void ChangeStatus()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите название задачи для изменения статуса: ");
        string title = Console.ReadLine();

        Task task = taskList.FirstOrDefault(t => t.Title == title);

        if (task != null)
        {
            Console.WriteLine("Выберите новый статус задачи:");
            Console.WriteLine("1. Не начато");
            Console.WriteLine("2. В процессе");
            Console.WriteLine("3. Завершено");
            string statusChoice = Console.ReadLine();

            switch (statusChoice)
            {
                case "1":
                    task.Status = "Не начато";
                    break;
                case "2":
                    task.Status = "В процессе";
                    break;
                case "3":
                    task.Status = "Завершено";
                    break;
                default:
                    Console.WriteLine("Некорректный выбор статуса.\n");
                    return;
            }

            Console.WriteLine("Статус задачи обновлен.\n");
        }
        else
        {
            Console.WriteLine("Задача не найдена.\n");
        }
    }

    // Метод для отображения задач по экологу
    static void DisplayTasksByEcologist()
    {
        if (!taskList.Any())
        {
            Console.WriteLine("Список задач пуст.\n");
            return;
        }

        Console.Write("Введите имя эколога для отображения его задач: ");
        string responsibleEcologist = Console.ReadLine();

        IEnumerable<Task> tasksByEcologist = taskList.Where(t => t.ResponsibleEcologist == responsibleEcologist);

        if (tasksByEcologist.Any())
        {
            foreach (Task? task in tasksByEcologist)
            {
                task.DisplayTask();
            }
        }
        else
        {
            Console.WriteLine("У данного эколога нет задач.\n");
        }
    }
}
