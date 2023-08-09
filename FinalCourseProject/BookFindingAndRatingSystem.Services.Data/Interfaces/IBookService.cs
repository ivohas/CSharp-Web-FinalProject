using BookFindingAndRatingSystem.Services.Data.Models.Book;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using BookFindingAndRatingSystem.Web.ViewModels.Rating;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> AllBooksAsync();

        Task<DetailsBookViewModel> GetBookByIdAsync(string id,string userId);
        Task<IEnumerable<PopularBookViewModel>> GetBooksByNumberOfSellsAsync();

        Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookByIdAsync(string authorId);
        Task AddBookToUserByIdAsync(string? userId, DetailsBookViewModel book);
        Task<IEnumerable<AllBookViewModel>> GetAllBookByUserId(string? userId);
        Task RemoveBookFromMyBooksAsync(string? userId, DetailsBookViewModel myBook);

        Task<AllBookFilteredAndPagedSerivceModel> AllAsync(AllBookQueryModel queryModel);
        Task EditBookAsync(EditBookViewModel book);
        Task<EditBookViewModel> GetBookForEditByIdAsync(string id);
        Task CreateNewBookAsync(AddBookViewModel model);
        Task AddRatingToBookAsync(string? userId, RatingViewModel review);
        Task<IEnumerable<PopularBookViewModel>> GetPopularBooksAsync();
    }
}
