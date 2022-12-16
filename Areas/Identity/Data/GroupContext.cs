using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;


namespace GroupWebProject.Data;

public class GroupContext : IdentityDbContext<AppUser>
{
    public GroupContext(DbContextOptions<GroupContext> options)
        : base(options)
    { 
    }

    public GroupContext()
    {
    }
    public DbSet<AdminDash> AdminDash { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Catgories { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<PaymentResponse> PaymentResponse { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        //builder.Entity<AdminDash>().HasData(new AdminDash { Id = 1, Name = "admin" });


        /*Category Electronics = new Category { Name = "Electronics", Slug = "electronics" };
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
             );*/

    }

       /* Category Electronics = new Category { Name = "Electronics", Slug = "electronics" };
        Category Apparel = new Category { Name = "Apparel", Slug = "apparel" };
        if (!context1.Products.Any())
            context1.Products.AddRange(
            new Product
            {

                Name = "Nintenda Swatch",
                Slug = "nintenda-swatch",
                Price = 299.99m,
                Category = Electronics,
                Description = "This year's hottest gaming console! Enjoy classic titles like 'Subpar Metroid' and 'Super Mario Sisters'!",
                Image = "NintendoSwatch.jpg"

            },
            new Product
            {
                Name = "SkollKandi Beanie",
                Slug = "skollkandi beanie",
                Price = 14.99m,
                Category = Apparel,
                Description = "beanie with ear-muff flaps for keeping your ears warm",
                Image = "SKBeanie.jpg"
            }
            

            );
        context1.SaveChanges();*/


    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }

    

    //public class DataContext : DbContext
    //{
    //    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Catgories { get; set; }

    //}
    
}