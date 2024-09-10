using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop_Candy.Models;
using WebShop_Candy.Service;
using WebShop_Candy.ViewModels;

namespace WebShop_Candy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandyRepository _candyRepo;

        public HomeController(ICandyRepository candyRepo)
        {
            _candyRepo = candyRepo;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepo.GetCandyOnSale
            };

            return View(homeViewModel);
        }

    }
}
