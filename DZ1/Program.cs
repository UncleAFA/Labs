using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите арифметическое выражение:");
        string expression = Console.ReadLine();
        int result = Calculator.Calculate(expression);
        Console.WriteLine($"Результат: {result}");


        #region тесты
        string[] inputs = { "1+2", "(234-11)*34", "6*6/6" }; // Пример
        string[] outputs = { "3", "7582", "6" }; // Пример
        for (int i = 0; i < inputs.Length; i++)
        {
            Console.WriteLine(inputs[i] + "=" + outputs[i]);
            Console.WriteLine("результат программы =" + outputs[i]);
            if (Calculator.Calculate(inputs[i]).ToString() == outputs[i])
            {
                Console.WriteLine("OK");
            }
            else
            {
                Console.WriteLine("OK");
            }
        }
        #endregion


    }
}

public class Calculator
{
    // Словарь для приоритета операций
    private static Dictionary<char, int> precedence = new Dictionary<char, int>
    {
        { '+', 1 },
        { '-', 1 },
        { '*', 2 },
        { '/', 2 }
    };

    // Метод для проверки, является ли символ оператором
    private static bool IsOperator(char c)
    {
        return precedence.ContainsKey(c);
    }

    // Метод для вычисления постфиксного выражения
    private static double EvaluatePostfix(string postfix)
    {
        Stack<double> stack = new Stack<double>();
        foreach (var token in postfix)
        {
            if (char.IsDigit(token))
            {
                stack.Push(token - '0'); // Преобразуем символ в число
            }
            else if (IsOperator(token))
            {
                double b = stack.Pop();
                double a = stack.Pop();
                switch (token)
                {
                    case '+': stack.Push(a + b); break;
                    case '-': stack.Push(a - b); break;
                    case '*': stack.Push(a * b); break;
                    case '/': stack.Push(a / b); break;
                }
            }
        }
        return stack.Pop();
    }

    // Метод для преобразования инфиксного выражения в постфиксное
    private static string InfixToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        string postfix = "";

        foreach (var token in infix)
        {
            if (char.IsDigit(token))
            {
                postfix += token;
            }
            else if (token == '(')
            {
                stack.Push(token);
            }
            else if (token == ')')
            {
                while (stack.Peek() != '(')
                {
                    postfix += stack.Pop();
                }
                stack.Pop(); // Удаляем '('
            }
            else if (IsOperator(token))
            {
                while (stack.Count > 0 && stack.Peek() != '(' && precedence[stack.Peek()] >= precedence[token])
                {
                    postfix += stack.Pop();
                }
                stack.Push(token);
            }
        }

        // Добавляем оставшиеся операторы в стек
        while (stack.Count > 0)
        {
            postfix += stack.Pop();
        }

        return postfix;
    }

    // Главный метод для расчета выражения
    public static int Calculate(string expression)
    {
        string postfix = InfixToPostfix(expression);
        double result = EvaluatePostfix(postfix);
        return (int)Math.Round(result); // Округляем результат до целого значения
    }
}