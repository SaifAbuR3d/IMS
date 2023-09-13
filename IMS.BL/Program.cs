using IMS.BL;
using Utility;

namespace IMS.UI
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("----------------  Inventory Management System ----------------\n\n");

            Inventory inventory = new();
            bool exit = false;

            do
            {
                DisplayMenu();
                int choice = UserInputHelper.GetValidInt("Enter your choice:  ");

                switch (choice)
                {
                    case 1:
                        string name = UserInputHelper.GetValidString("Enter product name: ");
                        decimal price = UserInputHelper.GetValidDecimal("Enter product price: ");
                        int quantity = UserInputHelper.GetValidInt("Enter product quantity: ");

                        inventory.AddProduct(name, price, quantity);
                        break;
                    case 2:
                        inventory.ViewProducts();
                        break;
                    case 3:
                        string productToEdit = UserInputHelper.GetValidString("Enter product name to edit: ");
                        string newName = UserInputHelper.GetValidString("Enter new product name if wanted, otherwise enter -1: ");
                        decimal newPrice = UserInputHelper.GetValidDecimal("Enter new product price if wanted, otherwise enter -1: ");
                        int newQuantity = UserInputHelper.GetValidInt("Enter new product quantity if wanted, otherwise enter -1: ");

                        inventory.UpdateProduct(productToEdit, newName, newPrice, newQuantity);
                        break;
                    case 4:
                        string productToDelete = UserInputHelper.GetValidString("Enter product name to delete: ");
                        inventory.RemoveProduct(productToDelete);
                        break;
                    case 5:
                        string productToSearch = UserInputHelper.GetValidString("Enter product name to search: ");
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
                System.Threading.Thread.Sleep(1000);
            } while (!exit);
        }
        private static void DisplayMenu()
        {
            Console.WriteLine("[1]. Add a product");
            Console.WriteLine("[2]. View all products");
            Console.WriteLine("[3]. Edit a product");
            Console.WriteLine("[4]. Delete a product");
            Console.WriteLine("[5]. Search for a product");
            Console.WriteLine("[6]. Exit");
        }
    }
}