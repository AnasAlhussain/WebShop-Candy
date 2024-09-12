using Microsoft.AspNetCore.Mvc;
using WebShop_Candy.Models;
using WebShop_Candy.Service;
using WebShop_Candy.ViewModels;

namespace WebShop_Candy.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ICandyRepository _candyRepo;
        private readonly ShoppingCart _shoppinCart;

        public ShoppingCartController(ICandyRepository candyRepository, ShoppingCart shoppingCart)
        {
            _candyRepo = candyRepository;
            _shoppinCart = shoppingCart;
        }

        public IActionResult Index()
        {
            _shoppinCart.ShoppingCartItems = _shoppinCart.GetShoppingCartItems();
            var shoppingCartViewModel = new ShoppinCartViewModel
            {
                ShoppingCart = _shoppinCart,
                shoppingCartTotal = _shoppinCart.GetShoppingCartTotal()
            };


            return View(shoppingCartViewModel);
        }


        public IActionResult AddToShoppingCart(int candyid)
        {
            var selectedCandy = _candyRepo.GetAllCandy.FirstOrDefault(c => c.CandyId == candyid);

            if (selectedCandy != null)
            {
                _shoppinCart.AddToCart(selectedCandy, 1);
            }

            return RedirectToAction("Index");
        }


        public IActionResult RemoveFromShoppingCart(int candyid)
        {
            var selectedCandy = _candyRepo.GetAllCandy.FirstOrDefault(c => c.CandyId == candyid);
            if (selectedCandy != null)
            {
                _shoppinCart.RemoveFromCart(selectedCandy);
            }

            return RedirectToAction("Index");
        }


        public IActionResult ClearCart()
        {
            _shoppinCart.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
