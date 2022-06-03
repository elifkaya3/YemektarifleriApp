using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        List<Category> GetRecipesByCategory(string name);
        void Create(Category entity, int[] categoryIds);
        void Update(Category entity, int[] categoryIds);
    }
}
