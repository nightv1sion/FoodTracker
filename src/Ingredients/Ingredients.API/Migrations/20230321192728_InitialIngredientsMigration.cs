using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ingredients.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialIngredientsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Proteins = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Carbs = table.Column<decimal>(type: "decimal(10,8)", nullable: false),
                    Fats = table.Column<decimal>(type: "decimal(10,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
