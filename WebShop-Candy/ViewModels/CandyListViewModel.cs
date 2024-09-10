using WebShop_Candy.Models;

namespace WebShop_Candy.ViewModels
{
    public class CandyListViewModel
    {
        public IEnumerable<Candy> Candies { get; set; }

        public string CurrentCategory { get; set; }


    }
}
