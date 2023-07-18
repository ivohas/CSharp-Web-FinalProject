using BookFindingAndRatingSystem.Data.Models;
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

        public async Task AddBookToUserByIdAsync(string? userId, DetailsBookViewModel book)
        {
            var alreadyInWishList = await this.dbContext.IdentityUserBooks
                .AnyAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == book.Id);

            if (alreadyInWishList == false)
            {
                var userBook = new IdentityUserBook
                {
                    BookId = Guid.Parse(book.Id),
                    UserId = Guid.Parse(userId)
                };

                try
                {
                    await this.dbContext.IdentityUserBooks.AddAsync(userBook);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw new Exception("Something went wrong!");
                }

            }
            // Already added
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

        public async Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookByIdAsync(string authorId)
        {
            return await this.dbContext.Books
                .Where(x => x.AutorId.ToString() == authorId)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id.ToString(),
                    ImageUrl = b.ImageUrl,
                    Title = b.Title,
                    Price = b.Price
                }).ToArrayAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllBookByUserId(string? userId)
        {
            IEnumerable<AllBookViewModel> myBooks = await this.dbContext.IdentityUserBooks
                 .Where(ub => ub.UserId.ToString() == userId)
                 .Select(b => new AllBookViewModel
                 {
                     Id = b.Book.Id.ToString(),
                     ImageUrl = b.Book.ImageUrl,
                     Title = b.Book.Title,
                     Price = b.Book.Price,                     
                 }).ToArrayAsync();

            return myBooks;
        }

        public async Task<DetailsBookViewModel> GetBookByIdAsync(string bookId)
        {

            var book = await dbContext.Books
                .Include(b => b.Autor)
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id.ToString() == bookId);
            if (book != null)
            {
                return new DetailsBookViewModel
                {
                    Id = book.Id.ToString(),
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    AutorName = $"{book.Autor.FirstName} {book.Autor.LastName}",
                    Category = book.Category.Name,
                    Publisher = book.Publisher.Name,
                    AutorId = book.AutorId,
                    SelledCopies = book.SelledCopies
                };
            }

            return null;
        }

        public async Task<IEnumerable<PopularBookViewModel>> GetBooksByNumberOfSellsAsync()
        {
            return await this.dbContext.Books
                .Select(b => new PopularBookViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    Pages = b.Pages,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    SelledCopies = b.SelledCopies
                }).OrderByDescending(b => b.SelledCopies)
                .ToArrayAsync();
        }


    }
}
