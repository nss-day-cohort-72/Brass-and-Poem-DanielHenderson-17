public class Program
{
    //available from outside the class, able to run without an instance of itself, and does not return a value.
    public static void Main()
    {

        //This line essentially creates and populates a list called productTypes with two specific ProductType objects. 
        var productTypes = new List<ProductType>
        {
            new ProductType { Id = 1, Title = "Poetry Book" },
            new ProductType { Id = 2, Title = "Brass Instrument" }
        };

        //Declare a list of product types and a list of products. When creating the lists, add at least two product types and five products.
        var products = new List<Product>
        {
            new Product { Name = "Haiku", Price = 15.99m, ProductTypeId = 1 },
            new Product { Name = "Sonnet Poems", Price = 12.50m, ProductTypeId = 1 },
            new Product { Name = "Trumpet", Price = 499.99m, ProductTypeId = 2 },
            new Product { Name = "Saxophone", Price = 699.50m, ProductTypeId = 2 },
            new Product { Name = "French Horn", Price = 289.00m, ProductTypeId = 2 }
        };

        while (true) //Becomes false if case 5 is selected as it will return and end the program. This is why I hard coded this to true.
        {
            DisplayMenu();
            //Basically the choice variable is set to the user's input of 1 through 5.
            var choice = Console.ReadLine();
            //Create a loop that asks the user to choose an option, and will continue running until the use selects 5, at which point the program will finish.
            switch (choice)
            {
                case "1":
                    //To test whether these methods work, add logic to the program loop to call the appropriate method when a user chooses an option:
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

    //Implement the DisplayMenu Method
    static void DisplayMenu()
    {
        //Display a welcome message for the application
        Console.WriteLine("Welcome to Brass & Poem");

        //The DisplayMenu method should display the following options to the console:
        Console.WriteLine("1. Display all products");
        Console.WriteLine("2. Delete a product");
        Console.WriteLine("3. Add a new product");
        Console.WriteLine("4. Update product properties");
        Console.WriteLine("5. Exit");
        Console.Write("Choose an option: ");
    }

    //Implement the DisplayAllProducts Method
    static void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
    {
        //Iterate over the products and display each product's name and price on a new line in the console. Start the line with the number of that product in the List (have the list start with 1, not 0).
        int index = 1;
        foreach (var product in products)
        {
            //Find the product type for each product and display it next to the product's name and price. I did this with LINQ First method.
            var productType = productTypes.First(productType => productType.Id == product.ProductTypeId);
            Console.WriteLine($"{index}. {product.Name} - ${product.Price} ({productType.Title})");
            index++;
        }
    }

    //Implement the DeleteProduct Method
    static void DeleteProduct(List<Product> products, List<ProductType> productTypes)
    {
        //Display the products and prompt the user to enter the number of the product they want to delete.
        DisplayAllProducts(products, productTypes);
        //Find the product with the provided number and remove it from the list of products.
        products.RemoveAt(int.Parse(Console.ReadLine()) - 1); //Remember that the list should start from 1.
        Console.WriteLine("Product deleted.");
    }

    //Implement the AddProduct Method
    static void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    //Prompt the user to enter the name and price of the new product (in this order).
    Console.Write("Enter product name: ");
    string name = Console.ReadLine();
    //Converts user input into a decimal value.
    Console.Write("Enter product price: ");
    decimal price = decimal.Parse(Console.ReadLine());

    //Display the ProductTypes and prompt the user to choose a type for the new product
    Console.WriteLine("Select a product type:");

    int index = 1;
    foreach (var productType in productTypes)
    {
        Console.WriteLine($"{index}. {productType.Title}");
        index++;
    }

    //Get the product type ID based on the user's choice
    int productTypeId = productTypes[int.Parse(Console.ReadLine()) - 1].Id;

    //Add the newly created product to the list of products.
    products.Add(new Product { Name = name, Price = price, ProductTypeId = productTypeId });
    Console.WriteLine("Product added.");
}


    //Implement the UpdateProduct Method
    static void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    //Display the products and prompt the user to enter the number of the product they want to update.
    DisplayAllProducts(products, productTypes);

    //Find the product with the provided number and retrieve its reference.
    var product = products[int.Parse(Console.ReadLine()) - 1]; //Remember that the list should start from 1.

    //Prompt the user to enter the updated name, price, and product type for the product (in that order).
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

    //Update the product's ProductTypeId if the user entered a new type.
    string typeInput = Console.ReadLine();
    if (!string.IsNullOrEmpty(typeInput))
        product.ProductTypeId = productTypes[int.Parse(typeInput) - 1].Id;

    Console.WriteLine("Product updated.");
}

}
