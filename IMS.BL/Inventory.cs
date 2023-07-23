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
    }
}