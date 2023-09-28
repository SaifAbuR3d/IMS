using IMS.Entities;

namespace IMS.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product? GetByName(string name);
    }

}
