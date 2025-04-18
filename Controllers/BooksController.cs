using complete_guide_to_aspnetcore_web_api.Data;
using complete_guide_to_aspnetcore_web_api.Data.Services;
using CompleteGuideToAspNetCoreWebApi.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace complete_guide_to_aspnetcore_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;
        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }
        


        // GET: api/Books
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            if (allBooks == null || !allBooks.Any())
            {
                return NotFound("No books found.");
            }
            return Ok(allBooks);
        }

        // GET: api/Books/{id}
        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            // Replace with actual logic to retrieve a book by ID
            var book = _booksService.GetBookById(id);
            if (book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {

            _booksService.AddBook(book);

            return Ok();
            
        }

        // PUT: api/Books/{id}
        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            if (updatedBook == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }
            // Replace with actual logic to update a book
            if (id <= 0 || book == null || string.IsNullOrEmpty(book.Title))
            {
                return BadRequest("Invalid input.");
            }

            return Ok(updatedBook);
        }

        // DELETE: api/Books/{id}
        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok($"Book with ID {id} deleted successfully.");
        }
    }
}