using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Security.Claims;
using Talabat.Dto;
using Talabat.Errors;
using TalabatCore.Entites.Order_Agreggate;
using TalabatCore.Irepository;
using TalabatCore.Servise;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderServise _orderServise;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IMapper mapper,IOrderServise orderServise,IUnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._orderServise = orderServise;
            this._unitOfWork = unitOfWork;
        }
        [ProducesResponseType(typeof(TalabatCore.Entites.Order_Agreggate.Order),StatusCodes.Status200OK)]
        [HttpPost]
        public async Task<ActionResult<TalabatCore.Entites.Order_Agreggate.Order>> CreaateOrder(OrderDto orderDto)
        {
            if (ModelState.IsValid) {
                var EmailBuyer = User.FindFirstValue(ClaimTypes.Email);
                var mapaddress = _mapper.Map<AdressDto, Address>(orderDto.address);
                var order = await _orderServise.createOrderAsync(EmailBuyer, orderDto.basketId, orderDto.DeliveryMethodeId, mapaddress);

                if (order is null)
                    return BadRequest(new ApiResponse(400));

               return Ok(order);
            }

            return BadRequest(new ApiResponse(400));

        }

    }
}
