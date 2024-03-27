using BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        // POST api/<BasketPositionsController>
        [HttpPost]
        [Route("AddProductToBasket")]
        public void Post(int userId,int productId)
        {
            _basketService.AddProductToBasket(productId, userId);
            return;
        }

        [HttpPatch]
        [Route("ChangeBasketPositionQuantity")]
        public void ChangeBasketPositionQuantity(int basketPositionId,int newQuantity)
        {
            _basketService.ChangeBasketPositionQuantity(basketPositionId, newQuantity);

            return;
        }


        [HttpDelete]
        [Route("RemoveProductFromBasket")]
        public void Delete(int id)
        {
            _basketService.RemoveProductFromBasket(id);

            return;
        }

    }
}
