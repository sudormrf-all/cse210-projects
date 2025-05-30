using System;

class Program
{
    static void Main()
    {
        // First order
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Anna Smith", address1);
        Product prod1 = new Product("Book", "B001", 12.50, 2);
        Product prod2 = new Product("Pen", "P010", 1.20, 5);
        Order order1 = new Order(customer1);
        order1.AddProduct(prod1);
        order1.AddProduct(prod2);

        // Second order
        Address address2 = new Address("77 King St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Liam Chen", address2);
        Product prod3 = new Product("Notebook", "N100", 5.00, 3);
        Product prod4 = new Product("Backpack", "BP05", 25.00, 1);
        Order order2 = new Order(customer2);
        order2.AddProduct(prod3);
        order2.AddProduct(prod4);

        // Display order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Order 1 Total Price: $" + order1.GetTotalPrice());
        Console.WriteLine("---------------------------");

        // Display order 2
        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Order 2 Total Price: $" + order2.GetTotalPrice());
        Console.WriteLine("---------------------------");
    }
}
