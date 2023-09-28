using IMS.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace IMS.DAL
{
    public class ProductRepositorySQL : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepositorySQL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Delete(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("DeleteProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", product.Name);

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
                     (string)reader["Name"],
                     (decimal)reader["Price"],
                     (int)reader["Quantity"]
                );

                products.Add(product);
            }

            return products;
        }
        public void Update(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("UpdateProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
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
                     (string)reader["Name"],
                     (decimal)reader["Price"],
                     (int)reader["Quantity"]
                );
            }

            return null;
        }

        public void Add(Product product)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand("InsertProduct", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", product.Name);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.Parameters.AddWithValue("@Quantity", product.Quantity);

            command.ExecuteNonQuery();
        }
    }
}
