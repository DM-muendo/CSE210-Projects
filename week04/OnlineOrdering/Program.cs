using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1
        var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        var customer1 = new Customer("John Doe", address1);
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A1001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "A1002", 25.50, 2));

        // Order 2
        var address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        var customer2 = new Customer("Jane Smith", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Desk Chair", "B2001", 150.00, 1));
        order2.AddProduct(new Product("Monitor", "B2002", 200.00, 2));
        order2.AddProduct(new Product("Keyboard", "B2003", 45.00, 1));

        // Display results for Order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.GetTotalCost():F2}\n");

        // Display results for Order 2
        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.GetTotalCost():F2}\n");
    }
}