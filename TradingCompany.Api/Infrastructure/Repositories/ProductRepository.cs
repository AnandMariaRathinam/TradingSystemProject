using Dapper;
using TradingCompany.Api.Application.Interfaces;
using TradingCompany.Api.Domain.Entities;
using TradingCompany.Api.Infrastructure.Data;

namespace TradingCompany.Api.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<Product>(
                "SELECT * FROM products ORDER BY id"
            );
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Product>(
                "SELECT * FROM products WHERE id = @Id",
                new { Id = id }
            );
        }

        public async Task<int> CreateAsync(Product product)
        {
            using var connection = _connectionFactory.CreateConnection();

            var sql = @"
                INSERT INTO products (name, sku, price, stock)
                VALUES (@Name, @Sku, @Price, @Stock)
                RETURNING id;
            ";

            return await connection.ExecuteScalarAsync<int>(sql, product);
        }
    }
}
