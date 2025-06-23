using System;
using System.Collections.Generic;
using System.Threading;

class User
{
    public string Login { get; set; }
    public string Name { get; set; }
    public bool IsPremium { get; set; }
}

class Program
{
    static void Main()
    {
        // Создаем список пользователей
        List<User> users = new List<User>
        {
            new User { Login = "user1", Name = "Алексей", IsPremium = false },
            new User { Login = "user2", Name = "Илья", IsPremium = true },
            new User { Login = "user3", Name = "Иван", IsPremium = false }
        };

        // Обработка каждого пользователя
        foreach (var user in users)
        {
            Console.WriteLine($"Привет, {user.Name}!");

            if (!user.IsPremium)
            {
                ShowAds();
            }
        }

        Console.WriteLine("Обработка завершена.");
    }

    static void ShowAds()
    {
        Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
        Thread.Sleep(1000);

        Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
        Thread.Sleep(2000);

        Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
        Thread.Sleep(3000);
    }
}
