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
                return false;
            }
            if (Products.Exists(_product => _product.Name == product.Name))
            {
                return false;
            }

            Products.Add(product);
            return true;
        }
    }
}