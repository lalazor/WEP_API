using complete_guide_to_aspnetcore_web_api.Data.Services;
using CompleteGuideToAspNetCoreWebApi.Data.Models.Views;
using Microsoft.AspNetCore.Mvc;

namespace complete_guide_to_aspnetcore_web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }
        
        
        [HttpGet]
        public IActionResult GetPublishers()
        {
            return Ok(new { Message = "List of publishers" });
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            return Ok(new { Message = $"Publisher with ID {id}" });
        }


        [HttpGet("get-publisher-books-with-authors-id/{id}")]
        public IActionResult GetPublisherWithBooksAndAuthorsById(int id)
        {
            var publisher = _publishersService.GetPublisherData(id);
            if (publisher == null)
            {
                return NotFound($"Publisher with ID {id} not found.");
            }
            return Ok(publisher);
        }


        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok(new { Message = "Publisher added successfully", Publisher = publisher });
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, [FromBody] object publisher)
        {
            return Ok(new { Message = $"Publisher with ID {id} updated", Publisher = publisher });
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            return Ok(new { Message = $"Publisher with ID {id} deleted" });
        }
    }
}