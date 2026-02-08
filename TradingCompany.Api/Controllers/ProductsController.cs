using Microsoft.AspNetCore.Mvc;
using TradingCompany.Api.Application.Services;
using TradingCompany.Api.Domain.Entities;
using TradingCompany.Api.Application.DTOs.Products;

namespace TradingCompany.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetProductsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetProductAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductRequest request)
        {
            var id = await _service.CreateProductAsync(request);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
    }
}
