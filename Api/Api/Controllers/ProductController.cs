using Api.Database;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("products/")]
    public class ProductController : Controller
    {
        private readonly MyDBContext _db;
        public ProductController(MyDBContext db)
        {
            _db = db;
        }
        [HttpGet("GetProducts")]
        public async Task<List<Product>> GetProducts()
        {
            return _db.Products.ToList();
        }
        [HttpPost]
        public async Task<Product> AddProduct(Product product)
        {
            var temp =  _db.Products.Add(product);
            _db.SaveChanges();
            return product;
        }
        [HttpPost("AddProducts")]
        public async Task<List<Product>> AddProducts(List<Product> products)
        {
            _db.Products.AddRange(products);
            _db.SaveChanges();
            return products;
        }
        [HttpPost("UpdateProducts")]
        public async Task<List<Product>> UpdateProducts(List<Product> products)
        {
            _db.Products.AddRange(products);
            _db.SaveChanges();
            return products;
        }
    }
}
