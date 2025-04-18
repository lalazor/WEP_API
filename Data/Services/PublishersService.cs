using System.Collections.Generic;
using CompleteGuideToAspNetCoreWebApi.Data.Models;
using CompleteGuideToAspNetCoreWebApi.Data.Models.Views;
using Data.Models;

namespace complete_guide_to_aspnetcore_web_api.Data.Services
{
    public class PublishersService
    {
        private  AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM book)
        {
            var _publisher = new Publisher
            {
                Name = book.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
    

    
}