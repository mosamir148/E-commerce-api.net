using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Errors;
using TalabatCore.Entites;
using TalabatCore.Irepository;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {

        public IBasketRepository _Basket { get; }
        public BasketsController(IBasketRepository basket)
        {
            _Basket = basket;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> getbasket(string id)
        {
            var result = await _Basket.GetBasketAsync(id);
            return result is null ? new CustomerBasket(id) : result;

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> Updateoradd(CustomerBasket basket)
        {
            var reult = _Basket.UpdateBasketAsync(basket);
           if(reult is null)
                return BadRequest(new ApiResponse(400));
           return Ok(reult);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> Deletebasket(string id)
        {
            return await _Basket.DeleteBasketAsync(id);
        }
  
    }
}
