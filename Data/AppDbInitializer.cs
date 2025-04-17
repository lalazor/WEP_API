using System;
using complete_guide_to_aspnetcore_web_api.Data;
using CompleteGuideToAspNetCoreWebApi.Data.Models;

namespace CompleteGuideToAspNetCoreWebApi.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                    // Database has been created, seed data
                    if (context != null)
                    {
                        SeedData(context);
                    }
                
            }
        }
        private static void SeedData(AppDbContext context)
        {
            // Check if the database is empty
            if (!context.Books.Any())
            {
                // Add initial data to the database
                context.Books.AddRange(
                    new Book { Title = "Book 10", Description = "Description 1", IsRead = false, Genre = "Fiction", Author = "Author 1", CoverURL = null, DateRead = null, Rate = null, DateAdded = DateTime.Now },
                    new Book { Title = "Book 2", Description = "Description 2", IsRead = true, Genre = "Non-Fiction", Author = "Author 2", CoverURL = null, DateRead = DateTime.Now.AddDays(-10), Rate = 5, DateAdded = DateTime.Now }
                );
                context.SaveChanges();
            }
        }
        public static void Initialize()
        {
            // Add your data initialization logic here
            Console.WriteLine("Data initialization logic goes here.");
        }
    }
}