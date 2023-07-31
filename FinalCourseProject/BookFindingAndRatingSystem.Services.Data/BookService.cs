using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Services.Data.Models.Book;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using BookFindingAndRatingSystem.Web.ViewModels.Book.Enum;
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
                    UserId = Guid.Parse(userId!)
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

        public async Task<AllBookFilteredAndPagedSerivceModel> AllAsync(AllBookQueryModel queryModel)
        {
            IQueryable<Book> booksQuery = this.dbContext.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                booksQuery = booksQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";
                booksQuery = booksQuery.Where(b => EF.Functions.Like(b.Title, wildCard)
                || EF.Functions.Like(b.Autor.FirstName, wildCard)
                || EF.Functions.Like(b.Autor.LastName, wildCard));
            }

            booksQuery = queryModel.BookSorting switch
            {
                BookSorting.LowestPrice => booksQuery.OrderBy(b => b.Price),
                BookSorting.TitleDescending => booksQuery.OrderByDescending(b => b.Title),
                BookSorting.TitleAscending => booksQuery.OrderBy(b => b.Title),
                BookSorting.HighestPrice => booksQuery.OrderByDescending(b => b.Price),
                BookSorting.MostCopiesSold => booksQuery.OrderByDescending(b => b.SelledCopies),
                _ => booksQuery
            };
            //Problem
            IEnumerable<AllBookViewModel> allBooks = await booksQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.BooksPerPage)
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Pages = b.Pages,
                    Price = b.Price
                }).Take(queryModel.BooksPerPage)
                .ToArrayAsync();

            int totalBook = booksQuery.Count();

            return new AllBookFilteredAndPagedSerivceModel()
            {
                TotalBooksCount = totalBook,
                Books = allBooks
            };
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

        public async Task CreateNewBookAsync(AddBookViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                Pages = model.Pages,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                PublishersId = model.PublisherId,
                AutorId = model.AuthorId,
                CategoryId = model.CategoryId,
                SelledCopies = model.SelledCopies
            };

            this.dbContext.Books.AddRange(book);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task EditBookAsync(EditBookViewModel book)
        {
            var bookToChange = await this.dbContext.Books.Where(b => b.Id.ToString() == book.Id).FirstOrDefaultAsync();

            if (bookToChange != null)
            {

                bookToChange.Title = book.Title;
                bookToChange.Price = book.Price;
                bookToChange.Description = book.Description;
                bookToChange.SelledCopies = book.SoldCopies;
                bookToChange.ImageUrl = book.ImageUrl;
                await this.dbContext.SaveChangesAsync();
            }
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

        public async Task<DetailsBookViewModel> GetBookByIdAsync(string bookId, string userId)
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
                    SelledCopies = book.SelledCopies,
                    AlreadyAddedByThisUser = await this.dbContext.IdentityUserBooks.Where(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == bookId).AnyAsync()
                };
            }

            return null;
        }

        public async Task<EditBookViewModel> GetBookForEditByIdAsync(string id)
        {

            var book = await dbContext.Books
                .Include(b => b.Autor)
                .FirstOrDefaultAsync(b => b.Id.ToString() == id);

            if (book != null)
            {
                return new EditBookViewModel
                {
                    Id = book.Id.ToString(),
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    AutorId = book.AutorId,
                    SoldCopies = book.SelledCopies
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
      

        public async Task RemoveBookFromMyBooksAsync(string? userId, DetailsBookViewModel myBook)
        {
            var userBook = await this.dbContext.IdentityUserBooks
                .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == myBook.Id);

            if (userBook != null)
            {
                this.dbContext.IdentityUserBooks.Remove(userBook);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
