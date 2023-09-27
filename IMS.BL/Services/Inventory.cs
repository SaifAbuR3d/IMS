using IMS.BL.DAL;
using IMS.BL.Entities;

namespace IMS.BL.Services
{
    public class Inventory
    {
        private readonly IProductRepository _productRepository;

        public Inventory(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public void ViewProducts()
        {
            var products = GetAllProducts();
            if (!products.Any())
            {
                Console.WriteLine("There are no products in the inventory.");
                return; 
            }
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }

        }

        public bool AddProduct(string name, decimal price, int quantity)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.");
            }
            if (price < 0)
            {
                throw new ArgumentException("Product price cannot be negative.");
            }
            if (quantity < 0)
            {
                throw new ArgumentException("Product quantity cannot be negative.");
            }

            if (ProductExists(name))
            {
                return false;
            }

            _productRepository.Add(name, price, quantity);
            return true;
        }

        public void SearchProduct(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            }

            if (!ProductExists(productName))
            {
                Console.WriteLine("The product was not found.");
                return; 
            }
            var product = _productRepository.GetByName(productName);
            Console.WriteLine(product);
        }

        public void UpdateProduct(string productName, string? newProductName,
                                  decimal? newProductPrice, int? newProductQuantity)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            }

            var product = _productRepository.GetByName(productName);

            if (product is null)
            {
                throw new InvalidOperationException("The product was not found.");
            }

            if (newProductName is not null and not "-1")
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

            _productRepository.Update(product);

        }

        public void RemoveProduct(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                throw new ArgumentException("Product name cannot be null or whitespace.", nameof(productName));
            }

            var product = _productRepository.GetByName(productName);

            if (product is null)
            {
                Console.WriteLine("The product was not found.");
                return; 
            }

            _productRepository.Delete(product);
        }

        private bool ProductExists(string productName)
        {
            var product = _productRepository.GetByName(productName);
            return product != null;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

    }
}
