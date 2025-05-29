using System;

namespace MiniCalculatorWithLogger
{
    public interface ILogger
    {
        void LogEvent(string message);
        void LogError(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void LogEvent(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[EVENT] {message}");
            Console.ResetColor();
        }

        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }
    }

    public interface IAdder
    {
        double Add(double a, double b);
    }

    public class Adder : IAdder
    {
        private readonly ILogger _logger;

        public Adder(ILogger logger)
        {
            _logger = logger;
        }

        public double Add(double a, double b)
        {
            double result = a + b;
            _logger.LogEvent($"Выполнено сложение: {a} + {b} = {result}");
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            IAdder adder = new Adder(logger);

            double num1 = 0;
            double num2 = 0;

            try
            {
                Console.Write("Введите первое число: ");
                num1 = Convert.ToDouble(Console.ReadLine());
                logger.LogEvent($"Пользователь ввёл первое число: {num1}");

                Console.Write("Введите второе число: ");
                num2 = Convert.ToDouble(Console.ReadLine());
                logger.LogEvent($"Пользователь ввёл второе число: {num2}");

                double result = adder.Add(num1, num2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Результат сложения: {result}");
            }
            catch (FormatException ex)
            {
                logger.LogError($"Ошибка при вводе числа: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: введено некорректное число.");
            }
            finally
            {
                Console.ResetColor();
                logger.LogEvent("Работа программы завершена");
                Console.WriteLine("Работа программы завершена.");
            }
        }
    }
}
