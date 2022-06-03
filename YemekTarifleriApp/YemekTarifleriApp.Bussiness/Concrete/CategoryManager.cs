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
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Create(Category entity, int[] categoryIds)
        {
            _categoryRepository.Create(entity, categoryIds);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity, int[] categoryIds)
        {
            _categoryRepository.Update(entity, categoryIds);
        }
    }
}
