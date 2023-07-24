using IMS.BL;

public class Program
{
    static void Main()
    {
        Console.WriteLine("----------------  Inventory Management System ----------------\n\n");

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

            int choice = UserInputHandler.GetValidInt("Enter your choice:  ");

            switch (choice)
            {
                case 1:
                    string name = UserInputHandler.GetValidString("Enter product name: ");
                    decimal price = UserInputHandler.GetValidDecimal("Enter product price: ");
                    int quantity = UserInputHandler.GetValidInt("Enter product quantity: ");

                    inventory.AddProduct(name, price, quantity);
                    break;
                case 2:
                    inventory.ViewProducts();
                    break;
                case 3:
                    string productToEdit = UserInputHandler.GetValidString("Enter product name to edit: ");
                    string newName = UserInputHandler.GetValidString("Enter new product name if wanted, otherwise enter -1: ");
                    decimal newPrice = UserInputHandler.GetValidDecimal("Enter new product price if wanted, otherwise enter -1: ");
                    int newQuantity = UserInputHandler.GetValidInt("Enter new product quantity if wanted, otherwise enter -1: ");

                    inventory.UpdateProduct(productToEdit, newName, newPrice, newQuantity);
                    break;
                case 4:
                    string productToDelete = UserInputHandler.GetValidString("Enter product name to delete: "); 
                    inventory.RemoveProduct(productToDelete);
                    break;
                case 5:
                    string productToSearch = UserInputHandler.GetValidString("Enter product name to search: ");
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
