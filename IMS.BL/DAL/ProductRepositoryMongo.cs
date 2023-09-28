using IMS.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IMS.DAL
{
    public class ProductRepositoryMongo : IProductRepository
    {

        private readonly string _connectionString;
        private IMongoCollection<Product> _collection;
        public ProductRepositoryMongo(string connectionString)
        {
            _connectionString = connectionString;
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("InventoryManagementSystemDB");

            _collection = db.GetCollection<Product>("Products");
        }

        public void Add (Product product)
        {
            _collection.InsertOne(product); 
        }

        public void Delete(Product product)
        {
            _collection.FindOneAndDelete(p => p.Name.Equals(product.Name));
        }

        public IEnumerable<Product> GetAll()
        {
            return _collection.Find(_ => true).ToList(); 
        }

        public Product? GetByName(string name)
        {
            return _collection.Find(p => p.Name == name).FirstOrDefault();
        }

        public void Update(Product product)
        {
            _collection.ReplaceOne(p => p.Name == product.Name, product);
        }
    }
}
