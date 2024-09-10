using WebShop_Candy.Data;
using WebShop_Candy.Models;

namespace WebShop_Candy.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAllCategories => _context.Categories;
    }
}
