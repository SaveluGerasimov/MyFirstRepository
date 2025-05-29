using System;
using System.Collections.Generic;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

class Program
{
    public delegate void SortEventHandler(List<string> list);
    public static event SortEventHandler OnSort;

    static void Main()
    {
        List<string> surnames = new List<string> { "Линков", "Уманов", "Куркин", "Кузнецов", "Морозов" };

        OnSort += SortAscending;
        OnSort += SortDescending;

        int choice = 0;

        while (true)
        {
            try
            {
                Console.WriteLine("Введите 1 для сортировки А-Я, 2 для сортировки Я-А:");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    throw new InvalidInputException("Введено не число");
                }

                if (choice != 1 && choice != 2)
                {
                    throw new InvalidInputException("Некорректный выбор. Введите 1 или 2.");
                }

                break;
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        if (choice == 1)
        {
            OnSort?.Invoke(surnames);
        }
        else if (choice == 2)
        {
            OnSort?.Invoke(surnames);
        }
    }

    static void SortAscending(List<string> list)
    {
        list.Sort();
        Console.WriteLine("\nФамилии отсортированы по А-Я:");
        foreach (var surname in list)
        {
            Console.WriteLine(surname);
        }
    }

    static void SortDescending(List<string> list)
    {
        list.Sort();
        list.Reverse();
        Console.WriteLine("\nФамилии отсортированы по Я-А:");
        foreach (var surname in list)
        {
            Console.WriteLine(surname);
        }
    }
}
