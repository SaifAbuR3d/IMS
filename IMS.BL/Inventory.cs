namespace IMS.BL
{
    public class Inventory
    {
        public Inventory()
        {
            Products = new List<Product>();
        }
        private List<Product> Products { get; }

        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("product cannot be null.");
            }
            if (Products.Exists(_product => _product.Name == product.Name))
            {
                throw new InvalidOperationException("The product name already exists.");
            }

            Products.Add(product);
            Console.WriteLine("The product has been added successfully");
            return true;
        }
        public bool AddProduct(string name, decimal price, int quantity)
        {
            var product = new Product(name, price, quantity);
            return AddProduct(product);
        }

        public void ViewProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("There is no products in the inventory.");
            }
            foreach (var product in Products)
            {
                Console.WriteLine(product);
            }
        }

        private Product? FindProduct(string productName)
        {
            var product = Products.Find(_product => _product.Name == productName);
            return product;
        }

        public void SearchProduct(string productName)
        {
            if (String.IsNullOrWhiteSpace(productName) || String.IsNullOrEmpty(productName))
            {
                throw new InvalidOperationException("Please enter a non-empty string");
            }

            var product = FindProduct(productName);
            if (product == null)
            {
                Console.WriteLine("The product was not found.");
            }
            else
            {
                Console.WriteLine(product);
            }
        }

        public void UpdateProduct(string productName, string? newProductName,
                                  decimal? newProductPrice, int? newProductQuantity)
        {
            var product = FindProduct(productName);
            if (product == null)
            {
                Console.WriteLine("The product was not found.");
                return;
            }
            if (newProductName is not null and not ("-1"))
            {
                product.Name = newProductName;
            }
            if (newProductPrice is not null and not (-1))
            {
                product.Price = (decimal)newProductPrice;
            }
            if (newProductQuantity is not null and not (-1))
            {
                product.Quantity = (int)newProductQuantity;
            }
            Console.WriteLine("The product was successfully updated.");
        }

        public void RemoveProduct(string productName)
        {
            var product = FindProduct(productName);
            if (product == null)
            {
                Console.WriteLine("There is no such product.");
            }
            else
            {
                Products.Remove(product);
                Console.WriteLine("The product was successfully deleted.");
            }
        }
    }
}
