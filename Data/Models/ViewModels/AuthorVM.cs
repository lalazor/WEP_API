using CompleteGuideToAspNetCoreWebApi.Data.Models.ViewModels;

namespace CompleteGuideToAspNetCoreWebApi.Data.Models.Views
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}