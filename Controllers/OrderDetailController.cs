using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderDetailController : ControllerBase
    {
        NorthwndContext db = new NorthwndContext();

        [HttpGet]
        public List<OrderDetail> OrderDetails()
        {
            return db.OrderDetails.ToList();
        }
        
        [HttpGet("{id}")]
        public OrderDetail GetOrderDetail(int id)
        {
            OrderDetail output = db.OrderDetails.Find(id);
            if (output != null)
            {
                return output;
            }
            else
            {
                return new OrderDetail()
                {
                    ProductId = -1
                };
            }
        }
        [HttpGet("UnitPrice/{price}")]
        public List<OrderDetail> GetByUnitPrice(double price) 
        {
            List<OrderDetail> order = db.OrderDetails.Where(o => o.UnitPrice == price).ToList();
            return order;
        }
        [HttpPost]
        public string CreateOrderDetail(OrderDetail order)
        {
            db.OrderDetails.Add(order);
            db.SaveChanges();

            return $"{order} was added to the database";
        }
        [HttpDelete("{id}")]
        public string DeleteOrderDetail(int id)
        {
            OrderDetail orderToDelete = db.OrderDetails.Find(id);
            if (orderToDelete != null)
            {
                db.OrderDetails.Remove(orderToDelete);
                db.SaveChanges();

                return $"Order at {id} was deleted sucessfully";
            }
            else
            {
                return $"There was no order at {id}, nothing was deleted";
            }
        }
    }
}
