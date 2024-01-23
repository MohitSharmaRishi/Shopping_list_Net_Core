using Api.Database;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ListedProductsController : ControllerBase
    {
        private readonly MyDBContext _db;
        public ListedProductsController(MyDBContext db)
        {
            _db = db;
        }
        
        [HttpGet("GetListedProducts")]
        public async Task<List<ListedProduct>> GetListedProducts()
        {
            return _db.ListedProducts.ToList();
        }

    }
}
