using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DAL
{
    public class ProductRepositoryFactory
    {
        public static IProductRepository CreateProductRepository()
        {
            var configuration = new ConfigurationBuilder()
                          .AddJsonFile("appsettings.json")
                          .Build();

            string connectionString = configuration.GetSection("constr").Value; 

            if (connectionString.StartsWith("mongo")) {
                return new ProductRepositoryMongo(connectionString);
            }

            return new ProductRepositorySQL(connectionString);

        }
    }
}
