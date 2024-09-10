using WebShop_Candy.Models;

namespace WebShop_Candy.Service
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
