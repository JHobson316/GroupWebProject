using GroupWebProject.Areas.Identity.Data;
using GroupWebProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
