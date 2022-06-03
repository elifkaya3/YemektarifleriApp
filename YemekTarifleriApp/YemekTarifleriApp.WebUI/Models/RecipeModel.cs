using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.WebUI.Models
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }

        [Required(ErrorMessage = "Tarif ismi boş geçilemez!")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Tarif ismi 4 ile 30 karakter arasında olmalıdır")]
        public string RecipeName { get; set; }
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Malzeme bölümü boş geçilemez.Lütfen malzemeleri giriniz!")]
        [StringLength(200,MinimumLength =30,ErrorMessage ="Malzemeler 30 ile 200 karakter arasında olmalıdır. ")]
        public string RecipeMaterial { get; set; }

        [Required(ErrorMessage ="Tarif detayları boş geçilemez.Lütfen nasıl yapıldığını yazınız.")]
        [StringLength(500,MinimumLength =50,ErrorMessage ="Lütfen 50 karakter ile 500 karakter arasında tarif detaylarını giriniz")]
        public string RecipeDescription { get; set; }
        public string Url { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
