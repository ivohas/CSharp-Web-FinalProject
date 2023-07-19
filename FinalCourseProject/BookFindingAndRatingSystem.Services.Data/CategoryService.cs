using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly BooksDbContext dbContext;

        public CategoryService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
            return await this.dbContext.Categories
                .Select(c => c.Name)
                .ToArrayAsync();
        }
    }
}
