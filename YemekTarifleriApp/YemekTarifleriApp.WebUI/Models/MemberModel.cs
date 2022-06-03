using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.WebUI.Models
{
    public class MemberModel
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Yazar ismi zorunludur!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Yazar ismi 5-50 karakter uzunluğunda olmalıdır!")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Yazar maili zorunludur!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Yazar maili 5-50 karakter uzunluğunda olmalıdır!")]
        [DataType(DataType.EmailAddress)]
        public string MemberMail{ get; set; }
        [Required(ErrorMessage = "Yazar kullanıcı adı zorunludur!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Yazar kullanıcı adı 5-50 karakter uzunluğunda olmalıdır!")]
        public string MemberUserName { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
