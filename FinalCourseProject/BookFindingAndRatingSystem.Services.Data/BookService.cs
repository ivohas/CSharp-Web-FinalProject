using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class BookService : IBookService
    {
        private readonly BooksDbContext dbContext;
        public BookService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> AllBooksAsync()
        {
            var books = await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    Pages = b.Pages,
                    ImageUrl = b.ImageUrl

                }).ToArrayAsync();
            
            return books;
        }
    }
}
