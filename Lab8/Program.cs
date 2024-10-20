using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Введите первое число: ");
            string input1 = Console.ReadLine();
            ValidateInput(input1);

            Console.Write("Введите второе число: ");
            string input2 = Console.ReadLine();
            ValidateInput(input2);

            // Преобразуем строки в вещественные числа
            double number1 = Convert.ToDouble(input1);
            double number2 = Convert.ToDouble(input2);

            // Проверка на деление на ноль
            if (number2 == 0)
            {
                throw new DivideByZeroException();
            }

            double result = number1 / number2;
            Console.WriteLine($"Результат деления: {result}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка преобразования: введено не число.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Ошибка: деление на ноль.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }

    static void ValidateInput(string input)
    {
        // Проверка на пустой ввод
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Ошибка: не введено число.");
        }

        // Проверка на длину числа (более 20 символов)
        if (input.Length > 20)
        {
            throw new ArgumentException("Ошибка: введено слишком длинное число.");
        }

        // Проверка на корректность формата числа
        if (!double.TryParse(input, out _))
        {
            throw new FormatException("Ошибка преобразования: введено некорректное число.");
        }
    }
}
//Основной метод Main:

//Программа запрашивает у пользователя ввод двух вещественных чисел.
//Используется метод ValidateInput для проверки корректности введенных данных.
//После валидации выполняется деление, и результат выводится на экран.
//Метод ValidateInput:

//Проверяет, не пустой ли ввод (выдает ошибку, если пустой).
//Проверяет, не превышает ли длина строки 20 символов (выдает ошибку, если превышает).
//Проверяет, можно ли преобразовать строку в вещественное число, используя double.TryParse.
//Обработка исключений:

//Включает обработку FormatException для некорректного ввода, DivideByZeroException для деления на ноль и пользовательские исключения для различных ошибок ввода.
//Общая обработка исключений для других непредвиденных ошибок.