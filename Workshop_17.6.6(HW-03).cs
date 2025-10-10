using System;
using System.Collections.Generic;

// Общий интерфейс для всех аккаунтов
public interface IAccount
{
    double Balance { get; set; }
    double Interest { get; set; }
    void CalculateInterest();
}

// Базовый абстрактный класс 
public abstract class AccountBase : IAccount
{
    public double Balance { get; set; }
    public double Interest { get; set; }
    public abstract void CalculateInterest();
}

// Реализация обычного аккаунта
public class RegularAccount : AccountBase
{
    public override void CalculateInterest()
    {
        // расчет процентной ставки обычного аккаунта по правилам банка
        this.Interest = this.Balance * 0.4;

        if (this.Balance < 1000)
            this.Interest -= this.Balance * 0.2;

        if (this.Balance >= 1000)
            this.Interest -= this.Balance * 0.4;
    }
}

// Реализация зарплатного аккаунта
public class SalaryAccount : AccountBase
{
    public override void CalculateInterest()
    {
        // расчет процентной ставки зарплатного аккаунта
        this.Interest = this.Balance * 0.5;
    }
}

// Пример
class Program
{
    static void Main()
    {
        List<IAccount> accounts = new List<IAccount>
        {
            new RegularAccount { Balance = 800 },
            new SalaryAccount { Balance = 1500 }
        };

        foreach (var account in accounts)
        {
            account.CalculateInterest();
            Console.WriteLine($"Account Type: {account.GetType().Name}, Balance: {account.Balance}, Interest: {account.Interest}");
        }
    }
}
