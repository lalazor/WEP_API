using CompleteGuideToAspNetCoreWebApi.Data.Models;

namespace Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        
        //navigation
        public List<BookAuthor> BookAuthors { get; set; } 

    }
}