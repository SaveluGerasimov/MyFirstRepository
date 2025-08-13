using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static string bookLink = "https://drive.google.com/uc?export=download&id=1jg43arS4KIUwO0-kao_ga7PWIPWBOXxo"; 
    static char[] conditionsSplit = { ' ', '\n', '\r' };

    static async Task Main()
    {
        int itemCount;

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string book = await client.GetStringAsync(bookLink);
                itemCount = book.Split(conditionsSplit, StringSplitOptions.RemoveEmptyEntries).Length;
                Console.WriteLine($"Количество слов/символов: {itemCount}.");

                // Тест для List<T>
                var list = new List<int>();
                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < itemCount; i++)
                {
                    list.Add(i);
                }

                stopwatch.Stop();
                Console.WriteLine($"Время вставки {itemCount} элементов в List<T>: {stopwatch.ElapsedMilliseconds} мс");

                // Тест для LinkedList<T>
                var linkedList = new LinkedList<int>();
                stopwatch.Restart();

                for (int i = 0; i < itemCount; i++)
                {
                    linkedList.AddLast(i);
                }

                stopwatch.Stop();
                Console.WriteLine($"Время вставки {itemCount} элементов в LinkedList<T>: {stopwatch.ElapsedMilliseconds} мс");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
