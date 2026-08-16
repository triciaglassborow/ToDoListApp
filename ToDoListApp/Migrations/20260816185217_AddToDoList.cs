using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class AddToDoList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoList",
                columns: table => new
                {
                    ListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList", x => x.ListID);
                });
            // Add a default list for the existing tasks
            migrationBuilder.InsertData(
                table: "ToDoList",
                columns: new[] { "ListID", "ListName" },
                values: new object[] { 1, "General" });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_ListID",
                table: "ToDoTask",
                column: "ListID");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_ToDoList_ListID",
                table: "ToDoTask",
                column: "ListID",
                principalTable: "ToDoList",
                principalColumn: "ListID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_ToDoList_ListID",
                table: "ToDoTask");

            migrationBuilder.DropTable(
                name: "ToDoList");

            migrationBuilder.DropIndex(
                name: "IX_ToDoTask_ListID",
                table: "ToDoTask");
        }
    }
}
