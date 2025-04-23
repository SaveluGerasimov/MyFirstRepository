using System;

class Program
{
    static void Main(string[] args)
    {
        var userData = User();
        DisplayUser(userData);
    }

    static (string firstName, string lastName, int age, bool hasPet, string[] petNames, string[] favoriteColors) User()
    {
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string lastName = Console.ReadLine();

        int age = CheckNum("Введите возраст: ");

        Console.Write("У вас есть питомец? (да/нет): ");
        bool hasPet = Console.ReadLine().Trim().ToLower() == "да";


        string[] petNames = null;

        if (hasPet == true)
        {
        
                if (hasPet)
                {
                    int numPets = CheckNum("Введите количество питомцев: ");
                    
                    string[] pet = new string[numPets];

                    for (int i = 0; i < numPets; i++)
                    {
                        Console.Write($"Введите кличку питомца {i + 1}: ");
                        pet[i] = Console.ReadLine();
                    }
                    petNames = pet;
            }
     
        }
        
        int numColors = CheckNum("Введите количество любимых цветов: ");

        string[] Colors = new string[numColors];

        for (int i = 0; i < numColors; i++)
        {
            Console.Write($"Введите любимый цвет {i + 1}: ");
            Colors[i] = Console.ReadLine();
        }

        string[] favoriteColors = Colors;

        return (firstName, lastName, age, hasPet, petNames, favoriteColors);
    }

    static int CheckNum(string message)
    {
        while (true)
        {
            Console.Write(message);

            if (int.TryParse(Console.ReadLine(), out int number))
            {
                if (number > 0)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число больше 0.");
                }
            }
        }
        
    }


    static void DisplayUser((string firstName, string lastName, int age, bool hasPet, string[] petNames, string[] favoriteColors) userData)
    {
        var (firstName, lastName, age, hasPet, petNames, favoriteColors) = userData;

        Console.WriteLine("\n Данные пользователя:");
        Console.WriteLine($"Имя: {firstName}");
        Console.WriteLine($"Фамилия: {lastName}");
        Console.WriteLine($"Возраст: {age}");

        if (hasPet)
        {
            Console.WriteLine($"У вас есть питомцы ({petNames.Length}): {string.Join(", ", petNames)}");
        }
        else
        {
            Console.WriteLine("У вас нет питомцев.");
        }
        Console.WriteLine($"Количество любимых цветов : {favoriteColors.Length}");
        Console.WriteLine($"Любимые цвета: {string.Join(", ", favoriteColors)}");
    }
}
