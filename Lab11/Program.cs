using System;
using System.Collections.Generic;

class Point
{
    // Свойства для доступа к координатам
    public double X { get; set; }
    public double Y { get; set; }

    // Конструктор
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    // Переопределение метода ToString для удобного вывода
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    // Метод для расчета расстояния до начала координат (0, 0)
    public double DistanceFromOrigin()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    // Метод для расчета расстояния до оси абсцисс (по координате Y)
    public double DistanceFromXAxis()
    {
        return Math.Abs(Y);
    }

    // Метод для расчета расстояния до оси ординат (по координате X)
    public double DistanceFromYAxis()
    {
        return Math.Abs(X);
    }

    // Метод для расчета расстояния до диагонали y = x
    public double DistanceFromDiagonal()
    {
        return Math.Abs(X - Y) / Math.Sqrt(2);
    }
}

// Компаратор для сортировки по расстоянию от начала координат
class CompareByDistanceFromOrigin : IComparer<Point>
{
    public int Compare(Point p1, Point p2)
    {
        return p1.DistanceFromOrigin().CompareTo(p2.DistanceFromOrigin());
    }
}

// Компаратор для сортировки по расстоянию от оси абсцисс (ось X)
class CompareByDistanceFromXAxis : IComparer<Point>
{
    public int Compare(Point p1, Point p2)
    {
        return p1.DistanceFromXAxis().CompareTo(p2.DistanceFromXAxis());
    }
}

// Компаратор для сортировки по расстоянию от оси ординат (ось Y)
class CompareByDistanceFromYAxis : IComparer<Point>
{
    public int Compare(Point p1, Point p2)
    {
        return p1.DistanceFromYAxis().CompareTo(p2.DistanceFromYAxis());
    }
}

// Компаратор для сортировки по расстоянию от диагонали y = x
class CompareByDistanceFromDiagonal : IComparer<Point>
{
    public int Compare(Point p1, Point p2)
    {
        return p1.DistanceFromDiagonal().CompareTo(p2.DistanceFromDiagonal());
    }
}

class Program
{
    // Метод для генерации случайного набора точек в квадрате [0,1] x [0,1]
    public static List<Point> GenerateRandomPoints(int count)
    {
        List<Point> points = new List<Point>();
        Random random = new Random();

        for (int i = 0; i < count; i++)
        {
            double x = random.NextDouble();
            double y = random.NextDouble();
            points.Add(new Point(x, y));
        }

        return points;
    }

    static void Main()
    {
        // Генерируем набор случайных точек
        List<Point> points = GenerateRandomPoints(10);

        // Выводим исходный набор точек
        Console.WriteLine("Исходный набор точек:");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }

        // Сортировка по расстоянию от начала координат
        points.Sort(new CompareByDistanceFromOrigin());
        Console.WriteLine("\nСортировка по расстоянию от начала координат:");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }

        // Сортировка по расстоянию от оси абсцисс (ось X)
        points.Sort(new CompareByDistanceFromXAxis());
        Console.WriteLine("\nСортировка по расстоянию от оси абсцисс (ось X):");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }

        // Сортировка по расстоянию от оси ординат (ось Y)
        points.Sort(new CompareByDistanceFromYAxis());
        Console.WriteLine("\nСортировка по расстоянию от оси ординат (ось Y):");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }

        // Сортировка по расстоянию от диагонали y = x
        points.Sort(new CompareByDistanceFromDiagonal());
        Console.WriteLine("\nСортировка по расстоянию от диагонали y = x:");
        foreach (var point in points)
        {
            Console.WriteLine(point);
        }
    }
}
