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
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category, RecipeAppContext>, ICategoryRepository
    {
        public void Create(Category entity, int[] categoryIds)
        {
            using (var context = new RecipeAppContext())
            {
                context.Categories.Add(entity);
                context.SaveChanges();
                entity.RecipeCategories = categoryIds
                    .Select(catId => new RecipeCategory
                    {
                        CategoryId = catId
                    }).ToList();
                context.SaveChanges();
            }
        }

        public Category GetByIdWithCategories(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetRecipesByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity, int[] categoryIds)
        {
            using (var context = new RecipeAppContext())
            {
                var category = context
                    .Categories
                    .Include(i => i.RecipeCategories)
                    .FirstOrDefault(i => i.CategoryId == entity.CategoryId);
                category.CategoryName = entity.CategoryName;
                category.Url = entity.Url;
                category.RecipeCategories = categoryIds
                    .Select(catId => new RecipeCategory()
                    {
                        CategoryId = catId
                    }).ToList();
                context.SaveChanges();
            }
        }
    }
}
