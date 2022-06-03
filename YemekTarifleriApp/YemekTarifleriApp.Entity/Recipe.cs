using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifleriApp.Entity
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string RecipeMaterial { get; set; }
        public string RecipeDescription { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public DateTime RecipeReleaseDate { get; set; }
        public List<RecipeMember> RecipeMembers { get; set; }
        public List<RecipeCategory> RecipeCategories { get; set; }
    }
}
