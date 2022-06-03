using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifleriApp.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; }
    }
}
