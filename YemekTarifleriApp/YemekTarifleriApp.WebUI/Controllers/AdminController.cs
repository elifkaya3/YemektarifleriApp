using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;
using YemekTarifleriApp.Bussiness.Concrete;
using YemekTarifleriApp.Entity;
using YemekTarifleriApp.WebUI.Models;

namespace YemekTarifleriApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categoryService;
        private readonly IMemberService _memberService;
        public AdminController(IRecipeService recipeService, ICategoryService categoryService, IMemberService memberService)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Admin Recipe
        public IActionResult RecipeList()
        {
            return View(_recipeService.GetAll());
        }
       
        public IActionResult RecipeCreate()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult RecipeCreate(RecipeModel model, int[] categoryIds, IFormFile file)
        {
            if (ModelState.IsValid && categoryIds.Length > 0 && file != null)
            {
                JobManager urlGenerate = new JobManager();
                var url = urlGenerate.MakeUrl(model.RecipeName);

                model.ImageUrl = urlGenerate.UploadImage(file, url);

                var recipe = new Recipe()
                {
                    RecipeName = model.RecipeName,
                    Url = model.Url,
                    RecipeMaterial = model.RecipeMaterial,
                    ImageUrl = model.ImageUrl,
                    RecipeDescription = model.RecipeDescription,
                    IsApproved = model.IsApproved,
                    IsHome = model.IsHome
                };
                _recipeService.Create(recipe, categoryIds);
                

                return RedirectToAction("RecipeList");
            }
            ViewBag.Categories = _categoryService.GetAll();

            if (categoryIds.Length > 0)
            {
                model.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    CategoryId = catId
                }).ToList();
            }
            else
            {
                ViewBag.CategoryMessage = "Lütfen tarifiniz için bir kategori seçimi yapınız!";
            }
            if (file == null)
            {
                ViewBag.ImageMessage = "Lütfen tarifiniz için resim seçiniz!";
            }
            return View(model);
        }

        public IActionResult RecipeEdit(int? id)
        {
            var entity = _recipeService.GetByIdWithCategories((int)id);
            var model = new RecipeModel()
            {
                RecipeId = entity.RecipeId,
                RecipeName = entity.RecipeName,
                RecipeMaterial = entity.RecipeMaterial,
                Url = entity.Url,
                RecipeDescription = entity.RecipeDescription,
                ImageUrl = entity.ImageUrl,
                IsApproved = entity.IsApproved,
                IsHome = entity.IsHome,
                SelectedCategories = entity
                    .RecipeCategories
                    .Select(i => i.Category)
                    .ToList()
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult RecipeEdit(RecipeModel model, int[] categoryIds, IFormFile file)
        {
            JobManager urlGenerate = new JobManager();
            var url = urlGenerate.MakeUrl(model.RecipeName);

            model.ImageUrl = urlGenerate.UploadImage(file, url);
            var entity = _recipeService.GetById(model.RecipeId);

            entity.RecipeName = model.RecipeName;
            entity.RecipeMaterial = model.RecipeMaterial; 
            entity.RecipeDescription = model.RecipeDescription;
            entity.Url = model.Url;
            entity.IsApproved = model.IsApproved;
            entity.IsHome = model.IsHome;
            entity.ImageUrl = model.ImageUrl;

            _recipeService.Update(entity, categoryIds);
            return RedirectToAction("RecipeList");
        }

        public IActionResult RecipeDelete(int recipeId)
        {
            var entity = _recipeService.GetById(recipeId);
            _recipeService.Delete(entity);
            return RedirectToAction("RecipeList");
        }


        //Admin Kategori

        public IActionResult CategoryList()
        {
            return View(_categoryService.GetAll());
        }
        public IActionResult CategoryCreate()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryModel model, int[] categoryIds)
        {
            if (!ModelState.IsValid)
            {
                JobManager urlGenerate = new JobManager();
                var url = urlGenerate.MakeUrl(model.CategoryName);
                var category = new Category()
                {
                    CategoryName = model.CategoryName,
                    Url = url
                };
                _categoryService.Create(category, categoryIds);

                return RedirectToAction("CategoryList");
            }
            ViewBag.Categories = _categoryService.GetAll();
            if (categoryIds.Length > 0)
            {
                model.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    CategoryId = catId
                }).ToList();
            }
            else
            {
                ViewBag.CategoryMessage = "Lütfen bir kategori seçimi yapınız!";
            }

            return View(model);
        }
        public IActionResult CategoryEdit(int id)
        {
            var entity = _categoryService.GetById(id);
            var model = new CategoryModel()
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Url = entity.Url
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryModel model, int[] categoryIds)
        {
            JobManager urlGenerate = new JobManager();
            var url = urlGenerate.MakeUrl(model.CategoryName);

            var entity = _categoryService.GetById(model.CategoryId);
            entity.CategoryName = model.CategoryName;
            entity.Url = model.Url;
            _categoryService.Update(entity, categoryIds);
            return RedirectToAction("CategoryList");
        }
        public IActionResult CategoryDelete(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            _categoryService.Delete(entity);
            return RedirectToAction("CategoryList");
        }

        //Admin Member 
        public IActionResult MemberList()
        {
            return View(_memberService.GetAll());
        }
        public IActionResult MemberCreate()
        {
            ViewBag.Members = _memberService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult MemberCreate(MemberModel model, int[] memberIds)
        {
            if (ModelState.IsValid)
            {
                JobManager urlGenerate = new JobManager();
                var member = new Member()
                {
                    MemberName = model.MemberName,
                    MemberMail=model.MemberMail,
                    MemberUserName=model.MemberUserName
                };
                _memberService.Create(member, memberIds);

                return RedirectToAction("MemberList");
            }
            ViewBag.Categories = _categoryService.GetAll();

            return View(model);
        }
        
        public IActionResult MemberEdit(int id)
        {
            var entity = _memberService.GetById(id);
            var model = new MemberModel()
            {
                MemberId = entity.MemberId,
                MemberName = entity.MemberName,
                MemberMail=entity.MemberMail,
                MemberUserName=entity.MemberUserName
            };
            ViewBag.Members = _memberService.GetAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult MemberEdit(MemberModel model, int[] memberIds)
        {
            var entity = _memberService.GetById(model.MemberId);
            entity.MemberName = model.MemberName;
            entity.MemberMail = model.MemberMail;
            entity.MemberUserName = model.MemberUserName;

            _memberService.Update(entity, memberIds);
            return RedirectToAction("MemberList");
        }
        public IActionResult MemberDelete(int memberId)
        {
            var entity = _memberService.GetById(memberId);
            _memberService.Delete(entity);
            return RedirectToAction("MemberList");
        }

    }
}
