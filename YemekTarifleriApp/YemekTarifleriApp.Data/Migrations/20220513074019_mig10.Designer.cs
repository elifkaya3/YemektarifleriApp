﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YemekTarifleriApp.Data.Concrete.EFCore;

namespace YemekTarifleriApp.Data.Migrations
{
    [DbContext(typeof(RecipeAppContext))]
    [Migration("20220513074019_mig10")]
    partial class mig10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("CategoryRecipe", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriesCategoryId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("CategoryRecipe");
                });

            modelBuilder.Entity("MemberRecipe", b =>
                {
                    b.Property<int>("MembersMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipesRecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MembersMemberId", "RecipesRecipeId");

                    b.HasIndex("RecipesRecipeId");

                    b.ToTable("MemberRecipe");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MemberMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberName")
                        .HasColumnType("TEXT");

                    b.Property<char>("MemberPassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("MemberUserName")
                        .HasColumnType("TEXT");

                    b.HasKey("MemberId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeMaterial")
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RecipeReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.RecipeCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeCategories");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.RecipeMember", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("RecipeId", "MemberId");

                    b.HasIndex("MemberId");

                    b.ToTable("RecipeMembers");
                });

            modelBuilder.Entity("CategoryRecipe", b =>
                {
                    b.HasOne("YemekTarifleriApp.Entity.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekTarifleriApp.Entity.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemberRecipe", b =>
                {
                    b.HasOne("YemekTarifleriApp.Entity.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekTarifleriApp.Entity.Recipe", null)
                        .WithMany()
                        .HasForeignKey("RecipesRecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.RecipeCategory", b =>
                {
                    b.HasOne("YemekTarifleriApp.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekTarifleriApp.Entity.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("YemekTarifleriApp.Entity.RecipeMember", b =>
                {
                    b.HasOne("YemekTarifleriApp.Entity.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekTarifleriApp.Entity.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Recipe");
                });
#pragma warning restore 612, 618
        }
    }
}
