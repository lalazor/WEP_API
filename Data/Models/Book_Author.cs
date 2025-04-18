using Data.Models;

namespace CompleteGuideToAspNetCoreWebApi.Data.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }

        // Navigation properties
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}