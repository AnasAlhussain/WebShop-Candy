using Microsoft.AspNetCore.Mvc;
using WebShop_Candy.Models;
using WebShop_Candy.ViewModels;

namespace WebShop_Candy.Component
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            this._shoppingCart = shoppingCart;
        }


        public IViewComponentResult Invoke()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();


            var shoppingCartViewModel = new ShoppinCartViewModel
            {
                ShoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
