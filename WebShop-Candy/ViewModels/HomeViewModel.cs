using WebShop_Candy.Models;

namespace WebShop_Candy.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Candy> CandyOnSale { get; set; }
    }
}
