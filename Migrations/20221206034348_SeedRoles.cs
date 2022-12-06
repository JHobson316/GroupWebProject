using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupWebProject.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string AdminRoleId = Guid.NewGuid().ToString();

        private string User1Id = "675fc22f-1b5a-4cd9-83c5-b0be46d64248";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO [dbo].[AspNetRoles] ([Id],[Name],[NormalizedName],[ConcurrencyStamp])
            VALUES ('{AdminRoleId}', 'Admin', 'ADMIN', null);");
        }


        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
        VALUES
           ('{User1Id}', '{AdminRoleId}');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
