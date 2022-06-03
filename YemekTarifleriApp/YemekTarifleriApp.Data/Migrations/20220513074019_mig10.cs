using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YemekTarifleriApp.Data.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberName = table.Column<string>(type: "TEXT", nullable: true),
                    MemberMail = table.Column<string>(type: "TEXT", nullable: true),
                    MemberUserName = table.Column<string>(type: "TEXT", nullable: true),
                    MemberPassword = table.Column<char>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipeName = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    RecipeMaterial = table.Column<string>(type: "TEXT", nullable: true),
                    RecipeDescription = table.Column<string>(type: "TEXT", nullable: true),
                    RecipeReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRecipe",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipe", x => new { x.CategoriesCategoryId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberRecipe",
                columns: table => new
                {
                    MembersMemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipesRecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRecipe", x => new { x.MembersMemberId, x.RecipesRecipeId });
                    table.ForeignKey(
                        name: "FK_MemberRecipe_Members_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberRecipe_Recipes_RecipesRecipeId",
                        column: x => x.RecipesRecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.CategoryId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeMembers",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeMembers", x => new { x.RecipeId, x.MemberId });
                    table.ForeignKey(
                        name: "FK_RecipeMembers_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeMembers_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_RecipesRecipeId",
                table: "CategoryRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecipe_RecipesRecipeId",
                table: "MemberRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_RecipeId",
                table: "RecipeCategories",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMembers_MemberId",
                table: "RecipeMembers",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "MemberRecipe");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "RecipeMembers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
