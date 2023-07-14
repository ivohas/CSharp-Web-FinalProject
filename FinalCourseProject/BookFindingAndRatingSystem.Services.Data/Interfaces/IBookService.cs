using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> AllBooksAsync();

        Task<DetailsBookViewModel> GetBookByIdAsync(string id);
    }
}
