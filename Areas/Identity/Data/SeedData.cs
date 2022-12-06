using GroupWebProject.Data;
using GroupWebProject.Models;
using Microsoft.EntityFrameworkCore;


namespace GroupWebProject.Areas.Identity.Data
{
    public class SeedData
    {
        public static void SeedDatabase(GroupContext Context)
        {
            Context.Database.Migrate();
            if(!Context.Products.Any()) {
                Category Electronics = new Category { Name = "Electronics", Slug = "electronics" };
                Category Apparel = new Category { Name = "Apparel", Slug = "apparel"};
                Context.Products.AddRange(
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
                        Name = "SkollKandi Beanie",
                        Slug = "beanie",
                        Price = 14.99m,
                        Category = Apparel,
                        Description = "beanie with ear-muff flaps for keeping your ears warm"
                    },
                    new Product
                    {
                        Name = "Bast Bluetooth Headphones",
                        Slug = "bast bluetooth headphones",
                        Price = 129.99m,
                        Category = Electronics,
                        Description = "Headphones with noise cancelling features, ",
                        Image = "Heaphones.jpg"
                    } 
                    );
                
                Context.SaveChanges();
            }
        } 
    }
}
