/// <summary>
/// Пользователь вводит размер квадратной матрицы n и значения элементов матрицы.
/// Программа находит минимальный элемент на главной диагонали (элементы, у которых совпадают индексы строки и столбца).
/// Определяется индекс столбца с этим минимальным элементом.
/// Создается новая матрица без этого столбца.
/// Программа выводит новую матрицу.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        // Вводим размерность матрицы
        int n;

        while (true)
        {
            Console.Write("Введите размерность матрицы (n): ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                n = result;
                break;
            }
            Console.WriteLine("Это не число. Повторите ввод.");
        }

        // Инициализируем матрицу
        int[,] matrix = new int[n, n];

        // Вводим элементы матрицы и находим минимальный элемент на главной диагонали
        int minElement = int.MaxValue;
        int minElementIndex = 0;

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                while (true)
                {
                    Console.Write($"Элемент [{i},{j}]: ");
                    if (int.TryParse(Console.ReadLine(), out int result))
                    {
                        matrix[i, j] = result;
                        // Проверяем только элементы главной диагонали
                        if (i == j && result < minElement)
                        {
                            minElement = result;
                            minElementIndex = j;  // Сохраняем индекс столбца с минимальным элементом
                        }
                        break;
                    }
                    Console.WriteLine("Это не число. Повторите ввод.");
                }

                
            }
        }

        Console.WriteLine($"\nМинимальный элемент главной диагонали: {minElement} в столбце {minElementIndex + 1}");

        // Выводим матрицу без столбца с минимальным элементом
        Console.WriteLine("\nМатрица после удаления столбца с минимальным элементом на главной диагонали:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j != minElementIndex)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}
