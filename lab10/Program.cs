using System;
using System.Collections.Generic;

class Product : IComparable<Product>
{
    // Закрытые поля
    private double quantityInKg;  // количество в кг
    private string originalQuantity;  // исходное представление количества
    private string name;  // название продукта

    // Свойства
    public double QuantityInKg => quantityInKg;
    public string OriginalQuantity => originalQuantity;
    public string Name => name;

    // Конструктор
    public Product(string quantity, string name)
    {
        this.name = name;
        originalQuantity = quantity;
        quantityInKg = ParseQuantity(quantity);  // парсим количество и конвертируем в кг

        if (quantityInKg < 0)
        {
            throw new ArgumentException("Количество не может быть отрицательным.");
        }
    }

    // Метод для парсинга количества и преобразования его в килограммы
    private double ParseQuantity(string quantity)
    {
        // Проверяем, что строка оканчивается на известные единицы измерения
        if (quantity.EndsWith("кг"))
        {
            return double.Parse(quantity.Replace("кг", "").Trim());
        }
        else if (quantity.EndsWith("л"))
        {
            return double.Parse(quantity.Replace("л", "").Trim()); // для воды и аналогичных жидкостей считаем 1л = 1кг
        }
        else if (quantity.EndsWith("т"))
        {
            return double.Parse(quantity.Replace("т", "").Trim()) * 1000;  // 1 т = 1000 кг
        }
        else if (quantity.EndsWith("г"))
        {
            return double.Parse(quantity.Replace("г", "").Trim()) / 1000;  // 1 г = 0.001 кг
        }
        else
        {
            throw new ArgumentException("Неизвестная единица измерения.");
        }
    }

    // Реализация метода сравнения из интерфейса IComparable<Product>
    public int CompareTo(Product other)
    {
        // Сравниваем количество в кг
        return quantityInKg.CompareTo(other.quantityInKg);
    }

    // Переопределяем метод ToString для удобного вывода
    public override string ToString()
    {
        return $"{name}: {originalQuantity} ({quantityInKg} кг)";
    }
}

class Program
{
    static void Main()
    {
        // Создаем список продуктов
        List<Product> products = new List<Product>();

        // Загружаем данные (вместо чтения из файла просто добавляем данные вручную)
        products.Add(new Product("3кг", "Апельсины"));
        products.Add(new Product("10л", "Квас"));
        products.Add(new Product("100л", "Вода"));
        products.Add(new Product("3780г", "Шоколад"));
        products.Add(new Product("10т", "Бананы"));
        products.Add(new Product("13кг", "Мангал"));

        // Выводим список до сортировки
        Console.WriteLine("Продукты до сортировки:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        // Сортируем список
        products.Sort();

        // Выводим список после сортировки
        Console.WriteLine("\nПродукты после сортировки:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
    }
}
