using IMS.Entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IMS.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(string name, decimal price, int quantity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("InsertProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Price", price);
            command.Parameters.AddWithValue("@Quantity", quantity);

            command.ExecuteNonQuery();
        }

        public void Delete(Product entity)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("DeleteProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", entity.Id);

            command.ExecuteNonQuery();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            using var command = new SqlCommand("GetAllProducts", connection);
            command.CommandType = CommandType.StoredProcedure;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var product = new Product
                (
                     (int)reader["Id"],
                     (string)reader["Name"],
                     (decimal)reader["Price"],
                     (int)reader["Quantity"]
                );

                products.Add(product);
            }

            return products;
        }

        public Product? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("GetProductById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                (
                     (int)reader["Id"],
                     (string)reader["Name"],
                     (decimal)reader["Price"],
                     (int)reader["Quantity"]
                );
            }

            return null;
        }


        public void Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("UpdateProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", product.Id);
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);

            command.ExecuteNonQuery();
        }


        public Product? GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using SqlCommand command = new SqlCommand("GetProductByName", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", name);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Product
                (
                     (int)reader["Id"],
                     (string)reader["Name"],
                     (decimal)reader["Price"],
                     (int)reader["Quantity"]
                );
            }

            return null;
        }

    }
}
