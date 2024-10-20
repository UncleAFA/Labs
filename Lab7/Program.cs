using System;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace HouseholdItemReflectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Type itemType = typeof(HouseholdItem);

            // Вывод информации о конструкторах
            Console.WriteLine("Constructors:");
            ConstructorInfo[] constructors = itemType.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }

            // Вывод информации о свойствах
            Console.WriteLine("\nProperties:");
            PropertyInfo[] properties = itemType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine(property);
            }

            // Вывод информации о методах
            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = itemType.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }

            // Вывод только тех свойств, которым назначен атрибут
            Console.WriteLine("\nProperties with MyCustomAttribute:");
            foreach (var property in properties)
            {
                if (Attribute.IsDefined(property, typeof(MyCustomAttribute)))
                {
                    Console.WriteLine(property);
                }
            }

            // Вызов метода DisplayInfo с использованием рефлексии
            Console.WriteLine("\nInvoking DisplayInfo method:");
            HouseholdItem item = (HouseholdItem)Activator.CreateInstance(itemType, "Vacuum Cleaner", "Cleaning", 199.99);
            MethodInfo displayInfoMethod = itemType.GetMethod("DisplayInfo");
            displayInfoMethod.Invoke(item, null);

            Console.ReadLine();
        }
    }
}
//Класс HouseholdItem:

//Содержит три свойства: Name, Category и Price. У свойства Name есть пользовательский атрибут MyCustomAttribute.
//Два конструктора: по умолчанию и с параметрами.
//Метод DisplayInfo выводит информацию о бытовом предмете.
//Класс MyCustomAttribute:

//Наследуется от System.Attribute и используется для аннотирования свойств.
//Класс Program:

//Получает тип HouseholdItem и выводит информацию о конструкторах, свойствах и методах с помощью рефлексии.
//Использует Attribute.IsDefined для проверки наличия атрибута у свойств.
//Создает экземпляр HouseholdItem с помощью Activator.CreateInstance и вызывает метод DisplayInfo с помощью рефлексии.