using System;

namespace MiniCalculator
{
    public interface IAdder
    {
        double Add(double a, double b);
    }

    public class Adder : IAdder
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAdder adder = new Adder();

            double num1 = 0;
            double num2 = 0;

            try
            {
                Console.Write("Введите первое число: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите второе число: ");
                num2 = Convert.ToDouble(Console.ReadLine());

                double result = adder.Add(num1, num2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Результат сложения: {result}");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: введено некорректное число!");
            }
            finally
            {
                Console.ResetColor();
                Console.WriteLine("Работа программы завершена)");
            }
        }
    }
}
