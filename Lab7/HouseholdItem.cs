using System;

namespace HouseholdItemReflectionExample
{
    public class HouseholdItem
    {
        // Свойство с атрибутом
        [MyCustomAttribute]
        public string Name { get; set; }

        // Свойство без атрибута
        public string Category { get; set; }

        // Свойство без атрибута
        public double Price { get; set; }

        // Конструктор по умолчанию
        public HouseholdItem() { }

        // Конструктор с параметрами
        public HouseholdItem(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        // Метод для вывода информации о бытовом предмете
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Category: {Category}, Price: ${Price}");
        }
    }

    // Определение атрибута
    [AttributeUsage(AttributeTargets.Property)]
    public class MyCustomAttribute : Attribute
    {
        // Дополнительные параметры атрибута можно добавить здесь
    }
}
