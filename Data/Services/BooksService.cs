using System.Collections.Generic;
using System.Linq;
using CompleteGuideToAspNetCoreWebApi.Data.Models;
using CompleteGuideToAspNetCoreWebApi.Data.Models.ViewModels;

namespace complete_guide_to_aspnetcore_web_api.Data.Services
{
    public class BooksService
    {
        // Add methods and properties as needed
        private  AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id) 
                   ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
        }
        public void AddBook(BookVM book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead : null,
                IsRead = book.IsRead,
                Rate = book.IsRead && book.Rate.HasValue ? book.Rate.Value : null,
                CoverURL = book.CoverURL,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }
        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
        }
    }
}