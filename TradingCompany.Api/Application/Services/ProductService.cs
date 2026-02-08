using TradingCompany.Api.Application.Interfaces;
using TradingCompany.Api.Domain.Entities;

namespace TradingCompany.Api.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
            => _repository.GetAllAsync();

        public Task<Product?> GetProductAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<int> CreateProductAsync(Product product)
            => _repository.CreateAsync(product);
    }
}
