using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;
using YemekTarifleriApp.Entity;
using YemekTarifleriApp.WebUI.Models;

namespace YemekTarifleriApp.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        private IRecipeService _recipeService;
        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public IActionResult Index()
        {
            return View(_recipeService.GetAll());
        }
        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Recipe recipe = _recipeService.GetRecipeDetails(url);
            if (recipe == null)
            {
                return NotFound();
            }
            RecipeDetailModel recipeDetail = new RecipeDetailModel()
            {
                Recipe = recipe,
                Categories = recipe.RecipeCategories.Select(i => i.Category).ToList()
            };
            return View(recipeDetail);
        }
        public IActionResult List(string category, int page = 1)
        {
            ViewBag.Message = "Ürün bulunamadı";
            ViewBag.AlertType = "warning";


            const int pageSize = 5;
            int totalItems = _recipeService.GetCountByCategory(category);
            var productListViewModel = new RecipeListViewModel()
            {
                PageInfo = new PageInfo
                {
                    TotalItems = totalItems,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Recipes = _recipeService.GetRecipesByCategory(category, page, pageSize)
            };
          
            return View(productListViewModel);
        }
    }
}
