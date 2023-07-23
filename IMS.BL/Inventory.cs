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
    }
}