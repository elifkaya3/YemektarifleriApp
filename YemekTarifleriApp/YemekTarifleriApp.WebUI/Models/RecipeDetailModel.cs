using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.WebUI.Models
{
    public class RecipeDetailModel
    {
        public Recipe Recipe { get; set; }
        public List<Category> Categories { get; set; }
    }
}
