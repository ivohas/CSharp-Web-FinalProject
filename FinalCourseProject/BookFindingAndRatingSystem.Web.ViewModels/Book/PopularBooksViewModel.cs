
namespace BookFindingAndRatingSystem.Web.ViewModels.Book
{
    public class PopularBooksViewModel
    {
        public PopularBooksViewModel()
        {
            this.PopularBooks = new HashSet<PopularBookViewModel>();
        }
        public int CurrentPage { get; set; }
        public IEnumerable<PopularBookViewModel> PopularBooks { get; set; }
        public int TotalBooksCount { get; set; }
        public int BooksPerPage { get; set; }
    }
}
