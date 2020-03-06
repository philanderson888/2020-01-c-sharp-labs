using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_63_ToDo_API_Users_Categories.Migrations
{
    public partial class addingseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "ToDoId", "ToDoName", "UserId" },
                values: new object[,]
                {
                    { 1, "Do This", null },
                    { 2, "And Do This", null },
                    { 3, "And Do This Also", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, "Fred" },
                    { 2, "Bob" },
                    { 3, "Pete" },
                    { 4, "Tim" },
                    { 5, "Serena" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "ToDoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);
        }
    }
}
