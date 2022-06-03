using Microsoft.EntityFrameworkCore.Migrations;

namespace YemekTarifleriApp.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "MemberRecipe");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Recipes");

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_RecipesRecipeId",
                table: "CategoryRecipe",
                column: "RecipesRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberRecipe_RecipesRecipeId",
                table: "MemberRecipe",
                column: "RecipesRecipeId");
        }
    }
}
