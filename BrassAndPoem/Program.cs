using System;
using System.Collections.Generic;
using System.Linq;

namespace BrassAndPoem
{
    class Program
    {
        static void Main(string[] args)
        {
            var productTypes = new List<ProductType>
            {
                new ProductType { Id = 1, Title = "Poetry Book" },
                new ProductType { Id = 2, Title = "Brass Instrument" }
            };

            var products = new List<Product>
            {
                new Product { Name = "Shakespeare's Sonnets", Price = 9.99m, ProductTypeId = 1 },
                new Product { Name = "The Odyssey", Price = 12.99m, ProductTypeId = 1 },
                new Product { Name = "Trumpet", Price = 199.99m, ProductTypeId = 2 },
                new Product { Name = "Trombone", Price = 299.99m, ProductTypeId = 2 },
                new Product { Name = "Flute", Price = 149.99m, ProductTypeId = 2 }
            };

            Console.WriteLine("Welcome to Brass & Poem");

            while (true)
            {
                DisplayMenu();

                var input = Console.ReadLine();

                if (input == "1")
                    DisplayAllProducts(products, productTypes);
                else if (input == "2")
                    DeleteProduct(products, productTypes);
                else if (input == "3")
                    AddProduct(products, productTypes);
                else if (input == "4")
                    UpdateProduct(products, productTypes);
                else if (input == "5")
                    break;
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Display all products");
            Console.WriteLine("2. Delete a product");
            Console.WriteLine("3. Add a new product");
            Console.WriteLine("4. Update product properties");
            Console.WriteLine("5. Exit");
        }

        static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
        {
            for (int i = 0; i < products.Count; i++)
            {
                var productType = productTypes.First(pt => pt.Id == products[i].ProductTypeId);
                Console.WriteLine($"{i + 1}. {products[i].Name} - ${products[i].Price} ({productType.Title})");
            }
        }

        static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
        {
            DisplayAllProducts(products, productTypes);
            Console.Write("Enter the number of the product to delete: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= products.Count)
            {
                products.RemoveAt(productNumber - 1);
            }
        }

        static void AddProduct(List<Product> products, List<ProductType> productTypes)
        {
            Console.Write("Enter the name of the new product: ");
            var name = Console.ReadLine();
            Console.Write("Enter the price of the new product: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                for (int i = 0; i < productTypes.Count; i++)
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                Console.Write("Select a product type: ");
                if (int.TryParse(Console.ReadLine(), out int productTypeNumber) && productTypeNumber > 0 && productTypeNumber <= productTypes.Count)
                {
                    var productTypeId = productTypes[productTypeNumber - 1].Id;
                    products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
                }
            }
        }

        static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
        {
            DisplayAllProducts(products, productTypes);
            Console.Write("Enter the number of the product to update: ");
            if (int.TryParse(Console.ReadLine(), out int productNumber) && productNumber > 0 && productNumber <= products.Count)
            {
                var product = products[productNumber - 1];
                Console.Write($"Enter the new name ({product.Name}): ");
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                    product.Name = name;

                Console.Write($"Enter the new price ({product.Price}): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                    product.Price = price;

                for (int i = 0; i < productTypes.Count; i++)
                    Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
                Console.Write("Select a new product type or press Enter to keep current: ");
                if (int.TryParse(Console.ReadLine(), out int productTypeNumber) && productTypeNumber > 0 && productTypeNumber <= productTypes.Count)
                    product.ProductTypeId = productTypes[productTypeNumber - 1].Id;
            }
        }
    }
}
