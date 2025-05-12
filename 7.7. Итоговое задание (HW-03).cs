using System;
using System.Collections.Generic;

abstract class Delivery
{
    public string Address { get; set; }
    public abstract void Deliver();
}

class HomeDelivery : Delivery
{
    public string CourierName { get; set; }

    public override void Deliver()
    {
        Console.WriteLine($"Доставка на дом по адресу: {Address} курьером {CourierName}.");
    }
}

class PickPointDelivery : Delivery
{
    public string PickupPoint { get; set; }

    public override void Deliver()
    {
        Console.WriteLine($"Доставка в пункт выдачи: {PickupPoint}. Адрес: {Address}.");
    }
}

class ShopDelivery : Delivery
{
    public string ShopName { get; set; }

    public override void Deliver()
    {
        Console.WriteLine($"Доставка в магазин: {ShopName}. Адрес: {Address}.");
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery { get; set; }
    public int Number { get; set; }
    public List<Product> Products { get; private set; } = new List<Product>();

    public Order(TDelivery delivery, int number)
    {
        Delivery = delivery;
        Number = number;
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
        Console.WriteLine($"Добавлен продукт: {product.Name}, цена: {product.Price}");
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"Заказ номер: {Number}");
        Console.WriteLine("Продукты:");
        foreach (var product in Products)
        {
            Console.WriteLine($"- {product.Name}: {product.Price}");
        }
        Delivery.Deliver();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var homeDelivery = new HomeDelivery()
        {
            Address = "Улица Крауля, дом №1",
            CourierName = "Олег"
        };

        var order1 = new Order<HomeDelivery>(homeDelivery, 1);
        order1.AddProduct(new Product("Клавиатура", 500));
        order1.AddProduct(new Product("Мышка", 150));

        order1.DisplayOrderDetails();

        var pickPointDelivery = new PickPointDelivery()
        {
            Address = "Улица Малышева, дом №13",
            PickupPoint = "ПВЗ Малышева"
        };

        var order2 = new Order<PickPointDelivery>(pickPointDelivery, 2);
        order2.AddProduct(new Product("Монитор", 15000));

        order2.DisplayOrderDetails();

        var shopDelivery = new ShopDelivery()
        {
            Address = "Улица 40 лет Октября, дом №10",
            ShopName = "Магазин 1140"
        };

        var order3 = new Order<ShopDelivery>(shopDelivery, 3);
        order3.AddProduct(new Product("Ноутбук", 20000));

        order3.DisplayOrderDetails();

        decimal totalCost(List<Product> products)
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }

        Console.WriteLine($"Общая стоимость заказа: {totalCost(order1.Products)}");
        Console.WriteLine($"Общая стоимость заказа: {totalCost(order2.Products)}");
        Console.WriteLine($"Общая стоимость заказа: {totalCost(order3.Products)}");
    }
}
