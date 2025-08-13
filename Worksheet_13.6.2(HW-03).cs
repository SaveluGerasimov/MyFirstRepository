using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static string bookLink = "https://drive.google.com/uc?export=download&id=1jg43arS4KIUwO0-kao_ga7PWIPWBOXxo";

    static async Task Main()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                string text = await client.GetStringAsync(bookLink);

                // Удаляем знаки пунктуации
                var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

                // Разбиваем текст на слова по пробелам и переводам строки
                var words = noPunctuationText
                    .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(w => w.ToLower()) // приводим к нижнему регистру для подсчёта без учёта регистра
                    .ToList();

                // Подсчитываем частоту каждого слова
                var wordFrequencies = words
                    .GroupBy(w => w)
                    .ToDictionary(g => g.Key, g => g.Count());

                // Сортируем по убыванию частоты и берем 10 самых популярных слов
                var top10Words = wordFrequencies
                    .OrderByDescending(kvp => kvp.Value)
                    .Take(10);

                Console.WriteLine("Топ 10 самых часто встречающихся слов:");
                foreach (var kvp in top10Words)
                {
                    Console.WriteLine($"{kvp.Key}: {kvp.Value} раз(а)");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
