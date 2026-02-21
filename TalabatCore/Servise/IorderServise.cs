using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites.Order_Agreggate;

namespace TalabatCore.Servise
{
    public interface IOrderServise
    {
        public Task<Order?> createOrderAsync(string Email,string BasketId,int DeliveryMethodeId,Address address);

        public Task<IReadOnlyList<Order>> GetOrderForUserAsync(string Email);

        public Task<Order> GetOrderByIdForUserAsync(int orderId,string Email);
    }
}
