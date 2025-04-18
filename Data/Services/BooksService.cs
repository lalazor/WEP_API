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
        public void AddBookWithAuthors(BookVM book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                DateRead = book.IsRead ? book.DateRead : null,
                IsRead = book.IsRead,
                Rate = book.IsRead && book.Rate.HasValue ? book.Rate.Value : null,
                CoverURL = book.CoverURL,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();

            foreach (var authorId in book.AuthorIds)
            {
                var _bookAuthor = new BookAuthor()
                {
                    BookId = newBook.Id,
                    AuthorId = authorId
                };
                _context.BookAuthors.Add(_bookAuthor);
                _context.SaveChanges();
            }
        }
        public Book UpdateBookById(int bookId, BookVM book)
        {
            var _existingBook = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (_existingBook == null)
            {
                throw new KeyNotFoundException($"Book with ID {bookId} not found.");
            }
            _existingBook.Title = book.Title;
            _existingBook.Description = book.Description;
            _existingBook.Genre = book.Genre;
            _existingBook.DateRead = book.IsRead ? book.DateRead : null;
            _existingBook.IsRead = book.IsRead;
            _existingBook.Rate = book.IsRead && book.Rate.HasValue ? book.Rate.Value : null;
            _existingBook.CoverURL = book.CoverURL;

            _context.Books.Update(_existingBook);
            _context.SaveChanges();
            return _existingBook;
        }
        public void DeleteBookById(int id)
        {
            var _book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }
        }
    }
}