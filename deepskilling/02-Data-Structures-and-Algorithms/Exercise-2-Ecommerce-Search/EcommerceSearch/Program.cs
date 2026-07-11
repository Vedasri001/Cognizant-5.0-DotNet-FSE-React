using System;

namespace EcommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101,"Keyboard","Electronics"),
                new Product(102,"Laptop","Electronics"),
                new Product(103,"Mouse","Electronics"),
                new Product(104,"Phone","Electronics"),
                new Product(105,"Tablet","Electronics")
            };

            Console.WriteLine("Linear Search:");

            Product result = Search.LinearSearch(products, "Laptop");

            if (result != null)
                Console.WriteLine($"{result.ProductId} {result.ProductName} {result.Category}");
            else
                Console.WriteLine("Product not found");

            Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

            Console.WriteLine();

            Console.WriteLine("Binary Search:");

            result = Search.BinarySearch(products, "Laptop");

            if (result != null)
                Console.WriteLine($"{result.ProductId} {result.ProductName} {result.Category}");
            else
                Console.WriteLine("Product not found");
        }
    }
}