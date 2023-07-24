using IMS.BL;
using System;

public class Program
{

    public static int getValidInt(string output)
    {
        int? input = null;
        while (!input.HasValue)
        {
            Console.Write(output);
            input = int.TryParse(Console.ReadLine(), out int i) ? i : new int?();
        }
        return (int)input; 
    }

    public static decimal getValidDecimal(string output) 
    {
        decimal? input = null;
        while (!input.HasValue)
        {
            Console.Write(output);
            input = decimal.TryParse(Console.ReadLine(), out decimal d) ? d : new decimal?();
        }
        return (decimal)input;
    }

    public static string getValidString(string output)
    {
        string? input = null;
        while (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
        {
            Console.Write(output);
            input = Console.ReadLine();
        }
        return (string)input;
    }

    static void Main()
    {
        Console.WriteLine("----------------  Inventory Management System ----------------");

        Inventory inventory = new();
        bool exit = false;

        do
        {
            Console.WriteLine("[1]. Add a product");
            Console.WriteLine("[2]. View all products");
            Console.WriteLine("[3]. Edit a product");
            Console.WriteLine("[4]. Delete a product");
            Console.WriteLine("[5]. Search for a product");
            Console.WriteLine("[6]. Exit");

            int choice = getValidInt("Enter your choice:  ");

            switch (choice)
            {
                case 1:
                    string name = getValidString("Enter product name: ");
                    decimal price = getValidDecimal("Enter product price: ");
                    int quantity = getValidInt("Enter product quantity: ");

                    inventory.AddProduct(name, price, quantity);
                    break;
                case 2:
                    inventory.ViewProducts();
                    break;
                case 3:
                    string productToEdit = getValidString("Enter product name to edit: ");
                    string newName = getValidString("Enter new product name if wanted, otherwise press enter: ");
                    decimal newPrice = getValidDecimal("Enter new product price if wanted, otherwise press enter: ");
                    int newQuantity = getValidInt("Enter new product quantity if wanted, otherwise press enter: ");

                    inventory.UpdateProduct(productToEdit, newName, newPrice, newQuantity);
                    break;
                case 4:
                    string productToDelete = getValidString("Enter product name to delete: "); 
                    inventory.RemoveProduct(productToDelete);
                    break;
                case 5:
                    string productToSearch = getValidString("Enter product name to search: ");
                    inventory.SearchProduct(productToSearch);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine();
        } while (!exit);
    }
}
