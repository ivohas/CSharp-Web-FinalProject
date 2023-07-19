using BookFindingAndRatingSystem.Web.Data;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<string>> AllCategoriesNameAsync();
    }
}
