using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupWebProject.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminDash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDash", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AdminDash",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDash");
        }
    }
}
