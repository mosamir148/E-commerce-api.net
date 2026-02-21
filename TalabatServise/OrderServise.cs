using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Entites.Order_Agreggate;
using TalabatCore.Irepository;
using TalabatCore.Servise;

namespace TalabatServise
{
    public class OrderServise : IOrderServise
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IGenericinterface<Product> _product;

        public Task<Order> createOrderAsync(string Email, string BasketId, int DeliveryMethodeId, TalabatCore.Entites.Order_Agreggate.Address address)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdForUserAsync(int orderId, string Email)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string Email)
        {
            throw new NotImplementedException();
        }
    }

}
