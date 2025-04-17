using complete_guide_to_aspnetcore_web_api.Data.Services;
using CompleteGuideToAspNetCoreWebApi.Data.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            // Replace with actual logic to retrieve books
            return Ok(new[] { "Book 1", "Book 2", "Book 3" });
        }

        // GET: api/Books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            // Replace with actual logic to retrieve a book by ID
            if (id <= 0)
            {
                return NotFound();
            }

            return Ok($"Book {id}");
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