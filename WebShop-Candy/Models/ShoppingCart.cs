using Microsoft.EntityFrameworkCore;
using WebShop_Candy.Data;

namespace WebShop_Candy.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }



        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);


            return new ShoppingCart(context) 
            {
                ShoppingCartId = cartId 
            };
        }

        public void AddToCart(Candy candy,int amount)
        {
            var shoppincartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Candy.CandyId == candy.CandyId && s.ShoppingCartId == ShoppingCartId);

            if(shoppincartItem == null)
            {
                shoppincartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Candy = candy,
                    Amount = amount
                };
                _appDbContext.ShoppingCartItems.Add(shoppincartItem);
                
            }
            else
            {
                shoppincartItem.Amount++;
            }


            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Candy candy)
        {
            var shoppincartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
               s => s.Candy.CandyId == candy.CandyId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;

            if (shoppincartItem != null)
            {
                if(shoppincartItem.Amount > 1)
                {
                    shoppincartItem.Amount--;
                    localAmount = shoppincartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppincartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Candy).ToList());
        }



        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }


        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId).
                Select(c => c.Candy.Price * c.Amount).Sum();

            return total;
        }
    }
}
