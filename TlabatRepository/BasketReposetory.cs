using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalabatCore.Entites;
using TalabatCore.Irepository;

namespace TlabatRepository
{
    public class BasketReposetory : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketReposetory(IConnectionMultiplexer redis)
        {
          _database = redis.GetDatabase();
        }



        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var result =await _database.StringGetAsync(id);
            return  result.IsNull ? null :JsonSerializer.Deserialize<CustomerBasket>(result) ;
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var result = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize<CustomerBasket>(basket),TimeSpan.FromDays(1));
            if (!result)
                return null;
            return await GetBasketAsync(basket.Id);

        }
    }
}
