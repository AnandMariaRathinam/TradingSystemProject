using TradingCompany.Api.Application.Interfaces;
using TradingCompany.Api.Application.DTOs.Products;
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

        public async Task<int> CreateProductAsync(CreateProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Sku = request.Sku,
                Price = request.Price,
                Stock = request.Stock
            };

            return await _repository.CreateAsync(product);
        }
    }
}
