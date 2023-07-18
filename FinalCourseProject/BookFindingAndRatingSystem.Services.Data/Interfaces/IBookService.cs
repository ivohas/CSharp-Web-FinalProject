using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> AllBooksAsync();

        Task<DetailsBookViewModel> GetBookByIdAsync(string id);
        Task<IEnumerable<PopularBookViewModel>> GetBooksByNumberOfSellsAsync();

        Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookByIdAsync(string authorId);
        Task AddBookToUserByIdAsync(string? userId, DetailsBookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBookByUserId(string? userId);
        Task RemoveBookFromMyBooksAsync(string? userId, DetailsBookViewModel myBook);
    }
}
