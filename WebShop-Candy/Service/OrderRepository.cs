using WebShop_Candy.Data;
using WebShop_Candy.Models;

namespace WebShop_Candy.Service
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext context, ShoppingCart shoppingCart)
        {
            _appDbContext = context;
            _shoppingCart = shoppingCart;
        }





        public void CreateOrder(Order order)
        {
           order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppincartItems = _shoppingCart.GetShoppingCartItems();

            foreach(var shoppingItem in shoppincartItems)
            {
                var orderDetail = new OrderDetails
                {
                    Amount = shoppingItem.Amount,
                    Price = shoppingItem.Candy.Price,
                    CandyId = shoppingItem.Candy.CandyId,
                    OrderId = order.OrderId
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
