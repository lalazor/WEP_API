using complete_guide_to_aspnetcore_web_api.Data.Services;
using CompleteGuideToAspNetCoreWebApi.Data.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace complete_guide_to_aspnetcore_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private  AuthorsService _authorsService;
        public AuthorController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        

        [HttpGet]
        public IActionResult GetAuthors()
        {
            return Ok(new { Message = "List of authors" });
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            return Ok(new { Message = $"Author with ID {id}" });
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok(new { Message = "Author added successfully", Author = author });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] object author)
        {
            return Ok(new { Message = $"Author with ID {id} updated", Author = author });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            return Ok(new { Message = $"Author with ID {id} deleted" });
        }

        [HttpGet("get-author-with-books-id/{id}")]
        public IActionResult GetAuthorWithBooksById(int id)
        {
            var author = _authorsService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found.");
            }
            return Ok(author);
        }
    }
}