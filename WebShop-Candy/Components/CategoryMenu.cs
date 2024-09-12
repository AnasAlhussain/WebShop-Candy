using Microsoft.AspNetCore.Mvc;
using WebShop_Candy.Service;

namespace WebShop_Candy.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this._categoryRepo = categoryRepository;
        }


        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepo.GetAllCategories.OrderBy(c => c.CategoryName);


            return View(categories);
        }
    }
}
