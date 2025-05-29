using System;

public class MyCustomException : Exception
{
    public MyCustomException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        Exception[] exceptions = new Exception[]
        {
            new DivideByZeroException("Деление на ноль"),
            new NullReferenceException("Обращение к объекту, равному null"),
            new IndexOutOfRangeException("Выход за границы массива"),
            new InvalidOperationException("Некорректная операция"),
            new MyCustomException("Мое собственное исключение")
        };

        foreach (var ex in exceptions)
        {
            try
            {
                throw ex;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"Исключение: {e.GetType().Name} - {e.Message}");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"Исключение: {e.GetType().Name} - {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Исключение: {e.GetType().Name} - {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Исключение: {e.GetType().Name} - {e.Message}");
            }
            catch (MyCustomException e)
            {
                Console.WriteLine($"Исключение: {e.GetType().Name} - {e.Message}");
            }
            finally
            {
                Console.WriteLine("Блок finally выполнен");
            }
        }

        Console.WriteLine("\nЗавершено выполнение задания 1.\n");
    }
}
