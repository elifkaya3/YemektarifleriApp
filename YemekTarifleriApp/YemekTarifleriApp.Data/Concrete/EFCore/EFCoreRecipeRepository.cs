using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Data.Abstract;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Data.Concrete.EFCore
{
    public class EFCoreRecipeRepository : EFCoreGenericRepository<Recipe, RecipeAppContext>, IRecipeRepository
    {
        private string ConvertLower(string text)
        {
            text = text.Replace("I", "i");
            text = text.Replace("İ", "i");
            text = text.Replace("ı", "i");

            text = text.ToLower();
            text = text.Replace("ç", "c");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");
            return text;
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new RecipeAppContext())
            {
                var recipes = context
                    .Recipes
                    .Where(i => i.IsApproved)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(category))
                {
                    recipes = recipes
                        .Include(i => i.RecipeCategories)
                        .ThenInclude(i => i.Category)
                        .Where(i => i.RecipeCategories.Any(a => a.Category.Url == category));
                }
                return recipes.Count();

            }
        }

        public List<Recipe> GetRecipesByCategory(string name, int page, int pageSize)
        {
            using (var context = new RecipeAppContext())
            {
                var recipes = context
                    .Recipes
                    .Where(i => i.IsApproved)
                    .AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    recipes = recipes
                         .Include(i => i.RecipeCategories)
                         .ThenInclude(i => i.Category)
                         .Where(i => i.RecipeCategories.Any(a => a.Category.Url == name));
                }
                return recipes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Recipe> GetRecipesByCategory(string name)
        {
            throw new NotImplementedException();
        }
        public Recipe GetRecipeDetails(string url)
        {
            using (var context = new RecipeAppContext())
            {
                return context
                    .Recipes
                    .Where(i => i.Url == url)
                    .Include(i => i.RecipeCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }
        public List<Recipe> GetHomePageFoods()
        {
            using (var context = new RecipeAppContext())
            {
                return context
                    .Recipes
                    .Where(i => i.IsApproved && i.IsHome)
                    .ToList();
            }
            
        }
        public Recipe GetByIdWithCategories(int id)
        {
            using (var context = new RecipeAppContext())
            {
                return context
                    .Recipes
                    .Where(i => i.RecipeId == id)
                    .Include(i => i.RecipeCategories)
                    .ThenInclude(i => i.Category)
                    .FirstOrDefault();
            }
        }

        public List<Recipe> GetSearchResult(string searchString)
        {
            searchString = ConvertLower(searchString);
            using (var context = new RecipeAppContext())
            {
                var recipes = context
                    .Recipes
                    .Where(i => i.IsApproved).ToList();
                foreach (var item in recipes)
                {
                    item.RecipeName = ConvertLower(item.RecipeName);
                    item.RecipeDescription = ConvertLower(item.RecipeDescription);
                }
                var recipes2 = recipes
                    .Where(i => i.RecipeName == searchString || i.RecipeDescription == searchString)
                    .ToList();

                return recipes2;
            }
        }

        public List<Recipe> GetHomePageRecipes()
        {
            using (var context = new RecipeAppContext())
            {
                return context
                    .Recipes
                    .Where(i => i.IsApproved && i.IsHome)
                    .ToList();
            }
        }

        public void Create(Recipe entity, int[] categoryIds)
        {
            using (var context = new RecipeAppContext())
            {
                context.Recipes.Add(entity);
                context.SaveChanges();
                entity.RecipeCategories = categoryIds
                    .Select(catId => new RecipeCategory
                    {
                        RecipeId = entity.RecipeId,
                        CategoryId = catId
                    }).ToList();
                context.SaveChanges();
            }
        }

        public void Update(Recipe entity, int[] categoryIds)
        {
            using (var context = new RecipeAppContext())
            {
                var recipe = context
                    .Recipes
                    .Include(i => i.RecipeCategories)
                    .FirstOrDefault(i => i.RecipeId == entity.RecipeId);
                recipe.RecipeName = entity.RecipeName;
                recipe.RecipeDescription = entity.RecipeDescription;
                recipe.Url = entity.Url;
                recipe.ImageUrl = entity.ImageUrl;
                recipe.IsApproved = entity.IsApproved;
                recipe.IsHome = entity.IsHome;
                recipe.RecipeCategories = categoryIds
                    .Select(catId => new RecipeCategory()
                    {
                        RecipeId = entity.RecipeId,
                        CategoryId = catId
                    }).ToList();
                context.SaveChanges();
            }
        }
    }
}
