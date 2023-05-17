using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        NorthwndContext db = new NorthwndContext();

        [HttpGet]
        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product output = db.Products.Find(id);
            if (output != null)
            {
                return output;
            }
            else
            {
                return new Product()
                {
                    ProductName = $"Error: id {id} is not a valid id in the db please try again",
                };
            }
        }
        [HttpGet("Category/{category}")]
        public List<Product> ProductByCategoryId(int category)
        {
            List<Product> products = db.Products.Where(c => c.CategoryId == category).ToList();
            return products;
        }
    }
}
