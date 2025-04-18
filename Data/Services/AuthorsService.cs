using System.Collections.Generic;
using CompleteGuideToAspNetCoreWebApi.Data.Models.Views;
using Data.Models;

namespace complete_guide_to_aspnetcore_web_api.Data.Services
{
    public class AuthorsService
    {
        private  AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM book)
        {
            var _author = new Author
            {
                FullName = book.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorById(int id)
        {
            var _author = _context.Authors
                .Where(a => a.Id == id)
                .Select(a => new AuthorWithBooksVM
                {
                    FullName = a.FullName,
                    BookTitles = a.BookAuthors
                        .Select(ba => ba.Book.Title)
                        .ToList()
                })
                .FirstOrDefault();

            return _author;
        }
    }
}