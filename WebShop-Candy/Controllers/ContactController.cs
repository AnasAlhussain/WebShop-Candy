using Microsoft.AspNetCore.Mvc;

namespace WebShop_Candy.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
