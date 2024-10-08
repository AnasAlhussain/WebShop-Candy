﻿using Microsoft.AspNetCore.Mvc;
using WebShop_Candy.Models;
using WebShop_Candy.Service;
using WebShop_Candy.ViewModels;

namespace WebShop_Candy.Controllers
{
    public class CandyController : Controller
    {

        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CandyController(ICandyRepository candyRepository,ICategoryRepository categoryRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
        }




        public IActionResult List(string category)
        {
            IEnumerable<Candy> candies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                candies = _candyRepository.GetAllCandy.OrderBy(c => c.CandyId);
                currentCategory = "All Candy";
            }
            else
            {
                candies = _candyRepository.GetAllCandy.
                    Where(c => c.Category.CategoryName == category);

                currentCategory = _categoryRepository.GetAllCategories.
                    FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new CandyListViewModel
            {
                Candies = candies,
                CurrentCategory = currentCategory,
            });
           
        }

        public IActionResult Details(int id)
        {
            var candy = _candyRepository.GetCandyById(id);
            if(candy == null)
            {
                return NotFound();
            }
            return View(candy);
        }
    }
}
