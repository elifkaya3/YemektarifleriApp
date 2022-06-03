using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Bussiness.Abstract
{
    public interface IRecipeService
    {
        Recipe GetById(int id);
        List<Recipe> GetAll();
        void Create(Recipe entity);
        void Update(Recipe entity);
        void Delete(Recipe entity);
        List<Recipe> GetRecipesByCategory(string name, int page, int pageSize);
        int GetCountByCategory(string category);
        Recipe GetRecipeDetails(string url);
        List<Recipe> GetSearchResult(string searchString);
        List<Recipe> GetHomePageRecipes();
        Recipe GetByIdWithCategories(int id);
        void Create(Recipe entity, int[] categoryIds);
        void Update(Recipe entity, int[] categoryIds);

    }
}
