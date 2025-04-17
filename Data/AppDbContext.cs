using CompleteGuideToAspNetCoreWebApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace complete_guide_to_aspnetcore_web_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
            
        }

        public DbSet<Book> Books { get; set; }
        // Define your DbSets here
        // Example:
        // public DbSet<EntityName> EntityNames { get; set; }
    }
}