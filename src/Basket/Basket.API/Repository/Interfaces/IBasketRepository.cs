using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repository.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart> GetBasket(string userName);
        Task<BasketCart> UpdateBasket(BasketCart basketCart);
        Task<bool> DeleteBasket(string userName);
    }
}