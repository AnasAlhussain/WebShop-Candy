namespace WebShop_Candy.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }

        public Candy Candy { get; set; }
        public int Amount { get; set; }

    }
}
