using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GroupWebProject.Models;
using System.Xml.Linq;


using System.Security.Cryptography.X509Certificates;


namespace GroupWebProject.Data;

public class GroupContext : IdentityDbContext<IdentityUser>
{
    public GroupContext(DbContextOptions<GroupContext> options)
        : base(options)
    { 
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Catgories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        builder.Entity<AdminDash>().HasData(new AdminDash { Id = 1, Name = "admin" });


        Category Electronics = new Category { Name = "Electronics", Slug = "electronics" };
        Category Apparel = new Category { Name = "Apparel", Slug = "apparel" };
        AddRange(
            new Product
            {

                Name = "Nintenda Swatch",
                Slug = "nintenda-switch",
                Price = 299.99m,
                Category = Electronics,
                Description = "This year's hottest gaming console! Enjoy classic titles like 'Subpar Metroid' and 'Super Mario Sisters'!",

            },
            new Product
            {
                Name = "SkollKandi",
                Slug = "beanie",
                Price = 14.99m,
                Category = Apparel,
                Description = "beanie with ear-muff flaps for keeping your ears warm"
            }
            );
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }

    public DbSet<AdminDash> AdminDash { get; set; }

    //public class DataContext : DbContext
    //{
    //    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Catgories { get; set; }

    //}
    

}
