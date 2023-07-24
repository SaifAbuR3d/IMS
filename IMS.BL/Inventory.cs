using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class Inventory
    {
        public Inventory()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }

        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null.");
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

        private Product FindProduct(String productName)
        {
            var product = Products.Find(_product => _product.Name == productName);
            return product;
        }

        public void SearchProduct(String productName)
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
            if (newProductName != null)
            {
                product.Name = newProductName; 
            }
            if (newProductPrice != null) 
            {
                product.Price = (decimal)newProductPrice; 
            }
            if (newProductQuantity != null)
            {
                product.Quantity = (int)newProductQuantity;  
            }
            Console.WriteLine("The product was successfully updated"); 
        }

    }
}
