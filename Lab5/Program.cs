class Program
{
    static void Main(string[] args)
    {
        // Путь к текстовому файлу
        string filePath = "F.txt";

        // Проверяем, существует ли файл
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        // Читаем текст из файла
        string text = File.ReadAllText(filePath);

        // Вызываем функцию для подсчета букв
        Dictionary<char, int> letterCount = CountLetters(text);

        // Выводим результат на экран
        foreach (KeyValuePair<char, int> entry in letterCount)
        {
            Console.WriteLine($"Буква '{entry.Key}' встречается {entry.Value} раз.");
        }
    }

    // Функция для подсчета букв в тексте
    static Dictionary<char, int> CountLetters(string text)
    {
        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        // Проходим по каждому символу текста
        foreach (char c in text)
        {
            // Приводим символ к нижнему регистру
            char lowerChar = Char.ToLower(c);

            // Проверяем, является ли символ буквой
            if (Char.IsLetter(lowerChar))
            {
                // Если буква уже есть в словаре, увеличиваем счётчик
                if (letterCount.ContainsKey(lowerChar))
                {
                    letterCount[lowerChar]++;
                }
                // Если буквы ещё нет, добавляем её в словарь
                else
                {
                    letterCount[lowerChar] = 1;
                }
            }
        }

        return letterCount;
    }
}
