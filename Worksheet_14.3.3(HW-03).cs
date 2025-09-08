using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 79990000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 79990000013, "innokentii@example.com"));

            // сортируем контакты сначала по имени, затем по фамилии
            var sortedPhoneBook = phoneBook
                .OrderBy(c => c.Name)
                .ThenBy(c => c.LastName)
                .ToList();

            const int pageSize = 2;
            int totalPages = (int)Math.Ceiling(sortedPhoneBook.Count / (double)pageSize);

            while (true)
            {
                Console.WriteLine($"Введите номер страницы от 1 до {totalPages}:");
                var input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                var parsed = Int32.TryParse(input.ToString(), out int pageNumber);

                if (!parsed || pageNumber < 1 || pageNumber > totalPages)
                {
                    Console.WriteLine("Страницы не существует");
                }
                else
                {
                    var pageContent = sortedPhoneBook
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);

                    foreach (var entry in pageContent)
                    {
                        Console.WriteLine($"{entry.Name} {entry.LastName}: {entry.PhoneNumber}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }

    public class Contact // модель класса
    {
        public Contact(string name, string lastName, long phoneNumber, string email) // метод-конструктор
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string Name { get; }
        public string LastName { get; }
        public long PhoneNumber { get; }
        public string Email { get; }
    }
}
