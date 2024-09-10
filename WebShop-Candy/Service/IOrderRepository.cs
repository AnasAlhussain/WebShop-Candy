using WebShop_Candy.Models;

namespace WebShop_Candy.Service
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
