using System.Collections.Generic;
using CompleteGuideToAspNetCoreWebApi.Data.Models;
using CompleteGuideToAspNetCoreWebApi.Data.Models.Views;
using Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public PublisherWithBooksAndAuthorsVM GetPublisherData(int id)
        {
            var _publisherData = _context.Publishers.Where(p => p.Id == id)
                .Select(p => new PublisherWithBooksAndAuthorsVM
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(b => new BookAuthorVM
                    {
                        BookName = b.Title,
                        BookAuthors = b.BookAuthors.Select(a => a.Author.FullName).ToList()
                    }).ToList()
                })
                .FirstOrDefault();

            return _publisherData;

        }
    }
    

    
}