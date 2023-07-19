using BookFindingAndRatingSystem.Web.ViewModels.Book.Enum;
using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
namespace BookFindingAndRatingSystem.Web.ViewModels.Book
{
    public class AllBookQueryModel
    {
        public AllBookQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.BooksPerPage = BooksPerPageConst;

            this.Categories = new HashSet<string>();
            this.Books = new HashSet<AllBookViewModel>();
        }
        public string? Category { get; set; }
        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }
        [Display(Name = "Sort books by")]
        public BookSorting BookSorting { get; set; }
        public int CurrentPage { get; set; }

        public int BooksCount { get; set; }

        public int BooksPerPage { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AllBookViewModel> Books { get; set; }
    }
}
