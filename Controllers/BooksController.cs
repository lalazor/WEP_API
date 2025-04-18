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
        [HttpGet("{id}")]
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
            // Replace with actual logic to create a book
            // if (book == null || string.IsNullOrEmpty(book.Title))
            // {
            //     return BadRequest("Book cannot be empty.");
            // }

            // return CreatedAtAction(nameof(GetBookById), new { id = 1 }, book); // Example response
        }

        // PUT: api/Books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] string book)
        {
            // Replace with actual logic to update a book
            if (id <= 0 || string.IsNullOrEmpty(book))
            {
                return BadRequest("Invalid input.");
            }

            return NoContent();
        }

        // DELETE: api/Books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            // Replace with actual logic to delete a book
            if (id <= 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}