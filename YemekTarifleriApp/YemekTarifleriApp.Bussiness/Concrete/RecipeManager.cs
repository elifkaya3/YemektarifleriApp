using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Bussiness.Abstract;
using YemekTarifleriApp.Data.Abstract;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Bussiness.Concrete
{
    public class RecipeManager : IRecipeService
    {
        IRecipeRepository _recipeRepository; 
        public RecipeManager(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public void Create(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Recipe entity)
        {
            _recipeRepository.Delete(entity);
        }

        public List<Recipe> GetAll()
        {
            return _recipeRepository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _recipeRepository.GetById(id);
        }

        public int GetCountByCategory(string category)
        {
            return _recipeRepository.GetCountByCategory(category);
        }

        public List<Recipe> GetRecipesByCategory(string name, int page, int pageSize)
        {
            return _recipeRepository.GetRecipesByCategory(name, page, pageSize);

        }

        public Recipe GetRecipeDetails(string url)
        {
            return _recipeRepository.GetRecipeDetails(url);
        }

        public void Update(Recipe entity)
        {
            throw new NotImplementedException();
        }

        public List<Recipe> GetSearchResult(string searchString)
        {
            return _recipeRepository.GetSearchResult(searchString);
        }

        public List<Recipe> GetHomePageRecipes()
        {
            return _recipeRepository.GetHomePageRecipes();
        }

        public Recipe GetByIdWithCategories(int id)
        {
            return _recipeRepository.GetByIdWithCategories(id);
        }

        public void Create(Recipe entity, int[] categoryIds)
        {
            _recipeRepository.Create(entity, categoryIds);
        }

        public void Update(Recipe entity, int[] categoryIds)
        {
            _recipeRepository.Update(entity, categoryIds);
        }
    }
}
