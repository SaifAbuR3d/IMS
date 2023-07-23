using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.BL
{
    public class Product
    {
        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
            => $"{Name}, Price: {Price}  In Stock: {Quantity}";

    }
}
