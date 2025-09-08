using InventoryAspireSample.API.Data;
using InventoryAspireSample.Shared.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InventoryAspireSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly AppDbContext _db;
        private readonly ILogger<ProductController> _logger;

        public ProductController(AppDbContext db, ILogger<ProductController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(CancellationToken ct)
        {
            _logger.LogInformation("Product GET called");
            var items = await _db.Product
                .OrderByDescending(p => p.CreatedAt)
                .AsNoTracking()
                .ToListAsync(ct);
            return Ok(items);
        }

        #region NoDBForFun

        // GET: api/<ProductController>
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    var products = new List<Product>
        //{
        //new Product
        //{
        //    Id = 1,
        //    Name = "Laptop",
        //    Description = "15-inch business laptop",
        //    Price = 1200.50m,
        //    Stock = 10,
        //    Category = "Electronics",
        //    CreatedAt = DateTime.Now.AddDays(-10),
        //    IsActive = true
        //},
        //new Product
        //{
        //    Id = 2,
        //    Name = "Wireless Mouse",
        //    Description = "Ergonomic wireless mouse",
        //    Price = 25.99m,
        //    Stock = 50,
        //    Category = "Accessories",
        //    CreatedAt = DateTime.Now.AddDays(-5),
        //    IsActive = true
        //},
        //new Product
        //{
        //    Id = 3,
        //    Name = "Office Chair",
        //    Description = "Comfortable office chair with lumbar support",
        //    Price = 180.00m,
        //    Stock = 5,
        //    Category = "Furniture",
        //    CreatedAt = DateTime.Now.AddDays(-2),
        //    IsActive = false
        //}
        //    };

        //    Console.WriteLine("Product Get-Method has been fired...");

        //    return products;
        //}


        #endregion



        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
