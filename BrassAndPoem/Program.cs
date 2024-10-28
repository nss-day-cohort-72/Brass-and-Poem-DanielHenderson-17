public class Program
{
    public static void Main()
    {
        var productTypes = new List<ProductType>
        {
            new ProductType { Id = 1, Title = "Poetry Book" },
            new ProductType { Id = 2, Title = "Brass Instrument" }
        };

        var products = new List<Product>
        {
            new Product { Name = "Haiku", Price = 15.99m, ProductTypeId = 1 },
            new Product { Name = "Sonnet Poems", Price = 12.50m, ProductTypeId = 1 },
            new Product { Name = "Trumpet", Price = 499.99m, ProductTypeId = 2 },
            new Product { Name = "Saxophone", Price = 699.50m, ProductTypeId = 2 },
            new Product { Name = "French Horn", Price = 289.00m, ProductTypeId = 2 }
        };

        while (true)
        {
            DisplayMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayAllProducts(products, productTypes);
                    break;
                case "2":
                    DeleteProduct(products, productTypes);
                    break;
                case "3":
                    AddProduct(products, productTypes);
                    break;
                case "4":
                    UpdateProduct(products, productTypes);
                    break;
                case "5":
                    return;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Welcome to Brass & Poem");
        Console.WriteLine("1. Display all products");
        Console.WriteLine("2. Delete a product");
        Console.WriteLine("3. Add a new product");
        Console.WriteLine("4. Update product properties");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }

    static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        int index = 1;
        foreach (var product in products)
        {
            var productType = productTypes.First(productType => productType.Id == product.ProductTypeId);
            Console.WriteLine($"{index}. {product.Name} - ${product.Price} ({productType.Title})");
            index++;
        }
    }

    static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        products.RemoveAt(int.Parse(Console.ReadLine()) - 1);
        Console.WriteLine("Product deleted.");
    }

    static void AddProduct(List<Product> products, List<ProductType> productTypes)
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Select a product type:");
        int index = 1;
        foreach (var productType in productTypes)
        {
            Console.WriteLine($"{index}. {productType.Title}");
            index++;
        }

        int productTypeId = productTypes[int.Parse(Console.ReadLine()) - 1].Id;
        products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
        Console.WriteLine("Product added.");
    }

    static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
    {
        DisplayAllProducts(products, productTypes);
        var product = products[int.Parse(Console.ReadLine()) - 1];

        Console.Write("Enter new name (leave blank to keep current): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name)) product.Name = name;

        Console.Write("Enter new price (leave blank to keep current): ");
        string priceInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(priceInput)) product.Price = decimal.Parse(priceInput);

        Console.WriteLine("Select a new product type (leave blank to keep current):");
        int index = 1;
        foreach (var productType in productTypes)
        {
            Console.WriteLine($"{index}. {productType.Title}");
            index++;
        }

        string typeInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(typeInput))
            product.ProductTypeId = productTypes[int.Parse(typeInput) - 1].Id;

        Console.WriteLine("Product updated.");
    }
}
