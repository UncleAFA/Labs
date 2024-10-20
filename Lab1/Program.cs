/// <summary>
/// Программа запрашивает у пользователя ввод основной строки.
/// Запрашивает подстроку, которую нужно найти в основной строке.
/// Метод CountSubstrings подсчитывает, сколько раз подстрока встречается в основной строке, используя метод IndexOf.
/// Результат выводится на экран.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        string inputString;
        string substring;

        while (true)
        {
            // Запрашиваем у пользователя ввод строки
            Console.Write("Введите строку:");
            inputString = Console.ReadLine();

            // Запрашиваем у пользователя подстроку для поиска
            Console.Write("Введите подстроку для поиска:");
            substring = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputString) || string.IsNullOrWhiteSpace(substring)) 
            {
                Console.WriteLine("Основная строка или подстрака пустая. Повторите ввод.");
                continue;
            }
            break;
        }
        // Подсчет количества вхождений подстроки
        int count = CountSubstrings(inputString, substring);

        Console.WriteLine($"Количество вхождений подстроки '{substring}' в строке: {count}");
    }

    // Метод для подсчета количества вхождений подстроки в строке
    static int CountSubstrings(string input, string substring)
    {
        int count = 0;
        int index = 0;

        // Пока подстрока находится в строке, увеличиваем счетчик
        while ((index = input.IndexOf(substring, index)) != -1)
        {
            count++;
            index += substring.Length;  // Переходим к следующему символу после найденной подстроки
        }

        return count;
    }
}
