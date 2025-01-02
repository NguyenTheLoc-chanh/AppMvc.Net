using AppMvc.Net.Models.Contacts;
using AppMvc.Net.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Models 
{
    // razorweb.models.MyBlogContext
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            // {
            //     var tableName = entityType.GetTableName();
            //     if (tableName.StartsWith("AspNet"))
            //     {
            //         entityType.SetTableName(tableName.Substring(6));
            //     }
            // }

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set;}
    }
}