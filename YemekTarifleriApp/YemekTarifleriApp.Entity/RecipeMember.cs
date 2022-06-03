using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekTarifleriApp.Entity
{
    public class RecipeMember
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
