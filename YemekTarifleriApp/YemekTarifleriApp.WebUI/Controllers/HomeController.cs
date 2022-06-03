using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;

namespace YemekTarifleriApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeService _recipeService;
        public HomeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public IActionResult Index()
        {
            return View(_recipeService.GetAll());
        }

       
    }
}
