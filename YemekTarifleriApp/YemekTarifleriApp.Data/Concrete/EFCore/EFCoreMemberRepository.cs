using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Data.Abstract;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Data.Concrete.EFCore
{
    public class EFCoreMemberRepository : EFCoreGenericRepository<Member, RecipeAppContext>, IMemberRepository
    {
        public void Create(Member entity, int[] memberIds)
        {
            using (var context = new RecipeAppContext())
            {
                context.Members.Add(entity);
                context.SaveChanges();
                entity.RecipeMembers = memberIds
                    .Select(recId => new RecipeMember
                    {
                        RecipeId = recId
                    }).ToList();
                context.SaveChanges();
            }
        }

        public void Update(Member entity, int[] memberIds)
        {
            using (var context = new RecipeAppContext())
            {
                var member = context
                    .Members
                    .Include(i => i.RecipeMembers)
                    .FirstOrDefault(i => i.MemberId == entity.MemberId);
                member.MemberName = entity.MemberName;
                member.MemberMail = entity.MemberMail;
                member.MemberUserName = entity.MemberUserName;
                member.RecipeMembers= memberIds
                    .Select(recId => new RecipeMember()
                    {
                        RecipeId = recId
                    }).ToList();
                context.SaveChanges();
            }
        }
    }
}
