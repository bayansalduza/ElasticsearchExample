using ElasticsearchExample.Domain.Model;
using ElasticsearchExample.ElasticsearchService.Services;
using ElasticsearchExample.Presentation.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ElasticsearchExample.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IElasticsearchService _elasticService;
        private const string IndexName = "products-index";

        public ProductsController(IElasticsearchService elasticService)
        {
            _elasticService = elasticService;
        }

        /// <summary>
        /// Elasticsearch'te "products-index" adında bir indeks oluşturur (yoksa).
        /// </summary>
        [HttpPost("create-index")]
        public async Task<IActionResult> CreateIndex()
        {
            await _elasticService.CreateIndexIfNotExistsAsync(IndexName);
            return Ok("Index created or already exists.");
        }

        /// <summary>
        /// Yeni Product oluşturur (ID sunucu tarafında üretilir).
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            // Sunucu tarafında ID'yi kendimiz atıyoruz.
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price
            };

            await _elasticService.InsertAsync(IndexName, product);
            return Ok($"Product {product.Id} inserted.");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip Product'ı döndürür.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _elasticService.GetByIdAsync<Product>(IndexName, id);
            if (product == null)
                return NotFound($"Product {id} not found.");

            return Ok(product);
        }

        /// <summary>
        /// Belirtilen ID'li Product'ı günceller.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateProductDto dto)
        {
            var product = new Product
            {
                Id = id, 
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price
            };

            await _elasticService.UpdateAsync(IndexName, id, product);
            return Ok($"Product {id} updated.");
        }

        /// <summary>
        /// Belirtilen ID'ye sahip Product'ı siler.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _elasticService.DeleteAsync(IndexName, id);
            return Ok($"Product {id} deleted.");
        }

        /// <summary>
        /// Arama metni eşleşen Product kayıtlarını döndürür (basit wildcard arama).
        /// </summary>
        [HttpGet("search/{searchText}")]
        public async Task<IActionResult> Search(string searchText)
        {
            var results = await _elasticService.SearchAsync<Product>(IndexName, searchText);
            return Ok(results);
        }
    }
}
