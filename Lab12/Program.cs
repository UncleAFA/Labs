using System;

class TicTacToe
{
    static char[,] board = new char[3, 3]; // Игровое поле 3x3
    static char currentPlayer = 'X'; // Текущий игрок ('X' или 'O')

    static void Main()
    {
        InitializeBoard(); // Инициализируем пустое игровое поле

        bool gameWon = false;
        int movesCount = 0;

        while (!gameWon && movesCount < 9) // Максимум 9 ходов (3x3 поле)
        {
            PrintBoard(); // Печатаем текущее состояние игрового поля
            PlayerMove(); // Ввод хода текущего игрока
            gameWon = CheckWinner(); // Проверяем победителя
            if (!gameWon)
            {
                SwitchPlayer(); // Меняем игрока
            }
            movesCount++; // Увеличиваем счетчик ходов
        }

        PrintBoard(); // Печатаем финальное состояние игрового поля

        if (gameWon)
        {
            Console.WriteLine($"Игрок {currentPlayer} победил!");
        }
        else
        {
            Console.WriteLine("Ничья!");
        }
    }

    // Метод для инициализации игрового поля пустыми клетками
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' '; // Пустая клетка
            }
        }
    }

    // Метод для вывода игрового поля на экран
    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("  0 1 2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    // Метод для обработки хода игрока
    static void PlayerMove()
    {
        int row = -1, col = -1;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine($"Игрок {currentPlayer}, введите координаты хода (строка и столбец через пробел):");
            string input = Console.ReadLine();
            string[] tokens = input.Split(' ');

            if (tokens.Length == 2 &&
                int.TryParse(tokens[0], out row) && row >= 0 && row < 3 &&
                int.TryParse(tokens[1], out col) && col >= 0 && col < 3 &&
                board[row, col] == ' ')
            {
                board[row, col] = currentPlayer; // Устанавливаем символ текущего игрока
                validInput = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }
        }
    }

    // Метод для переключения игрока
    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    // Метод для проверки, есть ли победитель
    static bool CheckWinner()
    {
        // Проверка строк
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                return true;
            }
        }

        // Проверка столбцов
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }

        // Проверка диагоналей
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }
}
