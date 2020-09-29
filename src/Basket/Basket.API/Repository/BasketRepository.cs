using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Basket.API.Repository.Interfaces;
using Newtonsoft.Json;

namespace Basket.API.Repository
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context;
        }

        public async Task<BasketCart> GetBasket(string userName)
        {
            var basket = await _context.Redis.StringGetAsync(userName);
            return basket.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basketCart)
        {
            var update =
                await _context.Redis.StringSetAsync(basketCart.UserName, JsonConvert.SerializeObject(basketCart));

            return update ? await GetBasket(basketCart.UserName) : null;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            return await _context.Redis.KeyDeleteAsync(userName);
        }
    }
}