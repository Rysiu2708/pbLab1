using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

   
        // POST api/<OrdersController>
        [HttpPost]
        [Route("GenerateOrder")]
        public void GenerateOrder(int userId)
        {
            _orderService.GenerateOrderFromBasket(userId);
        }

        // PUT api/<OrdersController>/5
        [HttpPatch]
        [Route("PayOrder")]
        public void PayOrder(int orderId, decimal amountPaid)
        {
            _orderService.PayOrder(orderId, amountPaid);
        }

  
    }
}
