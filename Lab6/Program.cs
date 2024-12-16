//Делегат StatsDelegate: Определяет тип делегата, который принимает массив целых чисел и возвращает словарь (число — количество вхождений).
//Генерация массива: Сначала создаем массив случайных целых чисел от 1 до 10 с заданным размером.
//Лямбда-выражение: Используем лямбда-выражение для группировки чисел и подсчета их вхождений. Метод GroupBy группирует числа, а ToDictionary создает словарь из этих групп.
//Вывод результатов: Перебираем полученный словарь и выводим на консоль количество вхождений для каждого числа.
namespace RandomNumberStatistics
{
    // Определяем делегат для обработки статистики
    public delegate Dictionary<int, int> StatsDelegate(int[] numbers);

    class Program
    {
        static void Main(string[] args)
        {
            // Генерация массива случайных целых чисел
            Random random = new Random();
            Console.Write("Введите размер массива:");
            int size =int.Parse(Console.ReadLine());// размер массива
            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(1, 11); // случайные числа от 1 до 10
            }

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{i})" + numbers[i]);                
            }

            // Используем лямбда-выражение для статистики
            StatsDelegate getStatistics = (int[] nums) =>
            {
                return nums.GroupBy(n => n)
                           .ToDictionary(g => g.Key, g => g.Count());
            };

            // Получаем статистику
            Dictionary<int, int> statistics = getStatistics(numbers);

            // Выводим результаты
            Console.WriteLine("Статистика чисел:");
            foreach (KeyValuePair<int, int> pair in statistics)
            {
                Console.WriteLine($"Число: {pair.Key}, Количество вхождений: {pair.Value}");
            }
        }
    }
}
