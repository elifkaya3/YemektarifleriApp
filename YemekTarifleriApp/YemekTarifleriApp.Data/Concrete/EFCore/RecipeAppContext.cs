using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YemekTarifleriApp.Entity;

namespace YemekTarifleriApp.Data.Concrete.EFCore
{
    public class RecipeAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipeMember> RecipeMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource= RecipeApp");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(rc => new { rc.CategoryId, rc.RecipeId });

            modelBuilder.Entity<RecipeMember>()
                .HasKey(rm => new { rm.RecipeId, rm.MemberId });
        }

       

    }
}
