using Microsoft.EntityFrameworkCore.Migrations;
namespace GroupWebProject.Migrations
{
    public partial class AdminRoleMigration : Migration
    {
        private string AdminRoleId = Guid.NewGuid().ToString();
        private string User1Id = "20d4c069-cc99-4ecb-8455-6c181b94c1c1";

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
    }
}