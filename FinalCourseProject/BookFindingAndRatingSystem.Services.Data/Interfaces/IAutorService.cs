using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IAutorService
    {
        Task<IEnumerable<AllAutorViewModel>> GetAllAutorsAsync();

        Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookAsync(string id);

        Task<AllAutorViewModel?> GetAutorByIdAsync(string id);
    }
}
