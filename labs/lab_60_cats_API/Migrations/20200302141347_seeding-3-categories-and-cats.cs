using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_60_cats_API.Migrations
{
    public partial class seeding3categoriesandcats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Bengal" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "Tabby" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Siamese" });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "CatName", "CategoryId" },
                values: new object[] { 1, "Sanjana", 1 });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "CatName", "CategoryId" },
                values: new object[] { 3, "George", 2 });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "CatId", "CatName", "CategoryId" },
                values: new object[] { 2, "Petrova", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "CatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
