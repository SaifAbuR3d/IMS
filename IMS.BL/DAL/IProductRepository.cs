using IMS.Entities;

namespace IMS.DAL
{
    public interface IProductRepository
    {
        Product? GetById(int id);
        IEnumerable<Product> GetAll();
        void Add(string name, decimal price, int quantity);
        void Update(Product entity);
        void Delete(Product entity);
        Product? GetByName(string name);
    }

}
