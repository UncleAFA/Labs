using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        // Шаг 1: Создаём и заполняем базу данных товаров
        ProductDatabase productDatabase = new ProductDatabase();
        productDatabase.AddProduct(new Product("Товар 1", 100.00m));
        productDatabase.AddProduct(new Product("Товар 2", 150.50m));
        productDatabase.AddProduct(new Product("Товар 3", 200.00m));

        // Сериализация базы данных товаров
        string dbFileName = "productDatabase.json";
        productDatabase.SaveToFile(dbFileName);

        // Десериализация базы данных товаров (если нужно)
        ProductDatabase loadedDatabase = ProductDatabase.LoadFromFile(dbFileName);

        // Шаг 2: Ввод данных покупателя
        Console.WriteLine("Введите имя покупателя:");
        string customerName = Console.ReadLine();
        Console.WriteLine("Введите адрес покупателя:");
        string customerAddress = Console.ReadLine();
        Console.WriteLine("Введите скидку покупателя:");
        double customerDiscount = Convert.ToDouble(Console.ReadLine());

        Customer customer = new Customer(customerName, customerAddress, customerDiscount);

        // Шаг 3: Создание заказа
        Order order = new Order(customer);

        // Шаг 4: Формирование строк заказа
        Console.WriteLine("Введите количество строк заказа:");
        int lineCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < lineCount; i++)
        {
            Console.WriteLine("Введите код товара:");
            string productCode = Console.ReadLine();

            // Проверяем, существует ли товар
            if (loadedDatabase.TryGetProduct(productCode, out Product product))
            {
                Console.WriteLine("Введите количество:");
                int quantity = int.Parse(Console.ReadLine());
                order.AddOrderLine(new OrderLine(quantity, product));
            }
            else
            {
                Console.WriteLine("Товар не найден.");
            }
        }

        // Шаг 5: Сохранение информации о заказе
        string orderFileName = "order.txt";
        File.WriteAllText(orderFileName, order.ToString());
        Console.WriteLine("Заказ сохранен в файл: " + orderFileName);
    }
}

[Serializable]
public class Customer
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double Discount { get; set; }

    public Customer(string name, string address, double discount)
    {
        Name = name;
        Address = address;
        Discount = discount;
    }
}

[Serializable]
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

[Serializable]
public class ProductDatabase
{
    private Dictionary<string, Product> products = new Dictionary<string, Product>();

    public void AddProduct(Product product)
    {
        products[product.Name] = product;
    }

    public bool TryGetProduct(string name, out Product product)
    {
        return products.TryGetValue(name, out product);
    }

    public void SaveToFile(string filePath)
    {
        string json = JsonConvert.SerializeObject(products.Values.ToList());
        File.WriteAllText(filePath, json);
    }

    public static ProductDatabase LoadFromFile(string filePath)
    {
        var db = new ProductDatabase();
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach (var product in products)
            {
                db.AddProduct(product);
            }
        }
        return db;
    }
}

[Serializable]
public class OrderLine
{
    public int Quantity { get; set; }
    public Product Product { get; set; }

    public OrderLine(int quantity, Product product)
    {
        Quantity = quantity;
        Product = product;
    }

    public decimal GetTotalPrice()
    {
        return Quantity * Product.Price;
    }
}

[Serializable]
public class Order
{
    public static int OrderCounter = 0;
    public int OrderNumber { get; private set; }
    public Customer Customer { get; private set; }
    public List<OrderLine> OrderLines { get; private set; }

    public Order(Customer customer)
    {
        OrderNumber = ++OrderCounter;
        Customer = customer;
        OrderLines = new List<OrderLine>();
    }

    public void AddOrderLine(OrderLine orderLine)
    {
        OrderLines.Add(orderLine);
    }

    public decimal GetTotalPrice()
    {
        decimal total = OrderLines.Sum(ol => ol.GetTotalPrice());
        return total - (total * (decimal)(Customer.Discount / 100));
    }

    public override string ToString()
    {
        string orderDetails = $"Заказ №{OrderNumber}\n" +
                              $"Покупатель: {Customer.Name}, Адрес: {Customer.Address}, Скидка: {Customer.Discount}%\n" +
                              "Строки заказа:\n";

        foreach (var line in OrderLines)
        {
            orderDetails += $"- {line.Product.Name}: {line.Quantity} шт. по {line.Product.Price:C} = {line.GetTotalPrice():C}\n";
        }

        orderDetails += $"Общая стоимость: {GetTotalPrice():C}";
        return orderDetails;
    }
}

//Классы:

//Customer: Хранит имя, адрес и скидку покупателя.
//Product: Хранит название и цену товара.
//ProductDatabase: Содержит ассоциативный массив (словарь) для хранения товаров. Реализует методы для добавления товаров, получения товара по коду, а также методы для сериализации и десериализации в JSON.
//OrderLine: Описывает строку заказа с количеством и продуктом. Методы для получения общей стоимости.
//Order: Хранит информацию о заказе, включая номер заказа, покупателя и строки заказа. Вычисляет общую стоимость с учетом скидки.
//Основная логика программы:

//Создает и заполняет базу данных товаров.
//Вводит данные о покупателе.
//Создает заказ для введенного покупателя.
//Формирует строки заказа на основе введенных кодов товаров и их количества.
//Сохраняет информацию о заказе в текстовый файл.
//Сериализация и десериализация:

//Используется библиотека Newtonsoft.Json для работы с JSON.
//Сериализация базы данных товаров в файл и десериализация из файла.