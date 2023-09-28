using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IMS.Entities
{

    [BsonIgnoreExtraElements]
    public class Product
    {
        private string _name;
        private decimal _price;
        private int _quantity;

        [BsonElement("Name")]
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be null or whitespace.");
                }
                _name = value;
            }
        }

        [BsonElement("Price")]
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Product price cannot be negative.");
                }
                _price = value;
            }
        }

        [BsonElement("Quantity")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Product quantity cannot be negative.");
                }
                _quantity = value;
            }
        }
        public Product(string name, decimal price, int quantity)
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
            _name = name;
            _price = price;
            _quantity = quantity;
        }
        public override string ToString() => $"{Name}, Price: {Price}  In Stock: {Quantity}";
    }
}