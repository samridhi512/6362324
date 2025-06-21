using System;

class Program
{
    static void Main(string[] args)
    {
        
        Product[] products = new Product[]
        {
            new Product(103, "Keyboard", "Electronics"),
            new Product(101, "Shoes", "Footwear"),
            new Product(105, "Mouse", "Electronics"),
            new Product(102, "T-shirt", "Apparel"),
            new Product(104, "Bag", "Accessories"),
        };

        Console.WriteLine("=== Linear Search ===");
        Console.Write("Enter product name to search: ");
        string name = Console.ReadLine();
        Product result1 = SearchFunctions.LinearSearch(products, name);
        Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

        
        Array.Sort(products, (p1, p2) => p1.ProductId.CompareTo(p2.ProductId));

        Console.WriteLine("\n=== Binary Search ===");
        Console.Write("Enter product ID to search: ");
        int id = int.Parse(Console.ReadLine());
        Product result2 = SearchFunctions.BinarySearch(products, id);
        Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");

        Console.ReadLine();
    }
}
