using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Services.Data.Models.Book
{
    public class AllBookFilteredAndPagedSerivceModel
    {
        public AllBookFilteredAndPagedSerivceModel()
        {
            this.Books = new HashSet<AllBookViewModel>();
        }
        public int TotalBooksCount { get; set; }

        public IEnumerable<AllBookViewModel> Books { get; set; }
    }
}
