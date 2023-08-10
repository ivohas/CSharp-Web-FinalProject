using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Services.Data.Models.Book;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using BookFindingAndRatingSystem.Web.ViewModels.Book.Enum;
using BookFindingAndRatingSystem.Web.ViewModels.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly BooksDbContext dbContext;

        public BookService(BooksDbContext dbContext, ILogger<BookService> logger)
        {
            this.dbContext = dbContext;
            this._logger = logger;
        }

        public async Task AddBookToUserByIdAsync(string? userId, DetailsBookViewModel book)
        {
            try
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

                    await this.dbContext.IdentityUserBooks.AddAsync(userBook);
                    await dbContext.SaveChangesAsync();
                }
                // Already added
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a book to user's wishlist.");
                throw; // Rethrow the exception
            }
        }


        public async Task AddRatingToBookAsync(string? userId, RatingViewModel review)
        {
            try
            {
                var alreadyExist = await this.dbContext.Ratings.FirstOrDefaultAsync(r => r.UserId.ToString() == userId && r.BookId == review.BookId);

                if (alreadyExist != null)
                {
                    alreadyExist.Rate = review.Rate;
                    // Swap 
                }
                else
                {
                    var reviewToAdd = new Rating()
                    {
                        Rate = review.Rate,
                        BookId = review.BookId,
                        UserId = review.UserId
                    };

                    this.dbContext.Ratings.Add(reviewToAdd);
                }
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a rating to the book.");
                throw; // Rethrow the exception
            }
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

            IEnumerable<AllBookViewModel> allBooks = await booksQuery
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Pages = b.Pages,
                    Price = b.Price
                })
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
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all books.");
                throw; // Rethrow the exception
            }
        }

        public async Task CreateNewBookAsync(AddBookViewModel model)
        {
            try
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
                    SelledCopies = model.SoldCopies ?? 0
                };

                this.dbContext.Books.AddRange(book);
                await this.dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new book.");
                throw; // Rethrow the exception
            }
        }

        public async Task EditBookAsync(EditBookViewModel book)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing a book.");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookByIdAsync(string authorId)
        {
            try
            {
                var booksByAuthor = await this.dbContext.Books
                    .Where(x => x.AutorId.ToString() == authorId)
                    .Select(b => new AllBookViewModel
                    {
                        Id = b.Id.ToString(),
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        Price = b.Price
                    })
                    .ToArrayAsync();

                return booksByAuthor;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books by author ID.");
                throw; // Rethrow the exception
            }
        }


        public async Task<IEnumerable<AllBookViewModel>> GetAllBookByUserId(string? userId)
        {
            try
            {
                IEnumerable<AllBookViewModel> myBooks = await this.dbContext.IdentityUserBooks
                     .Where(ub => ub.UserId.ToString() == userId)
                     .Select(b => new AllBookViewModel
                     {
                         Id = b.Book.Id.ToString(),
                         ImageUrl = b.Book.ImageUrl,
                         Title = b.Book.Title,
                         Price = b.Book.Price,
                     })
                     .ToArrayAsync();

                return myBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books by user ID.");
                throw; // Rethrow the exception
            }
        }

        public async Task<DetailsBookViewModel> GetBookByIdAsync(string bookId, string userId)
        {
            try
            {
                var book = await dbContext.Books
                    .Include(b => b.Autor)
                    .Include(b => b.Publisher)
                    .Include(b => b.Category)
                    .FirstOrDefaultAsync(b => b.Id.ToString() == bookId);

                var ratingForBook = await this.dbContext.Ratings
                    .Where(r => r.BookId.ToString() == bookId)
                    .Select(x => x.Rate)
                    .ToListAsync();

                int averageRate = 0;
                if (ratingForBook.Count() != 0)
                {
                    averageRate = (int)Math.Round(ratingForBook.Average());
                }

                if (book != null)
                {
                    bool alreadyAddedByUser = await this.dbContext.IdentityUserBooks
                        .Where(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == bookId)
                        .AnyAsync();

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
                        AverageRate = averageRate,
                        AlreadyAddedByThisUser = alreadyAddedByUser
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching book details by ID.");
                throw; // Rethrow the exception
            }
        }

        public async Task<EditBookViewModel> GetBookForEditByIdAsync(string id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching book details for editing.");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<PopularBookViewModel>> GetBooksByNumberOfSellsAsync()
        {
            try
            {
                var popularBooks = await this.dbContext.Books
                    .Select(b => new PopularBookViewModel
                    {
                        Id = b.Id.ToString(),
                        Title = b.Title,
                        Description = b.Description,
                        Pages = b.Pages,
                        Price = b.Price,
                        ImageUrl = b.ImageUrl,
                        SelledCopies = b.SelledCopies
                    })
                    .OrderByDescending(b => b.SelledCopies)
                    .ToArrayAsync();

                return popularBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching books by number of sells.");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<PopularBookViewModel>> GetPopularBooksAsync()
        {
            try
            {
                var popularBooks = await dbContext.Books
                    .OrderByDescending(book => book.SelledCopies)
                    .Select(book => new PopularBookViewModel
                    {
                        Id = book.Id.ToString(),
                        Title = book.Title,
                        Description = book.Description,
                        Pages = book.Pages,
                        ImageUrl = book.ImageUrl,
                        Price = book.Price,
                        SelledCopies = book.SelledCopies
                    })
                    .ToListAsync();

                return popularBooks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching popular books.");
                throw; // Rethrow the exception
            }
        }

        public async Task RemoveBookFromMyBooksAsync(string? userId, DetailsBookViewModel myBook)
        {
            try
            {
                var userBook = await this.dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == myBook.Id);

                if (userBook != null)
                {
                    this.dbContext.IdentityUserBooks.Remove(userBook);
                    await this.dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing a book from user's collection.");
                throw; // Rethrow the exception
            }
        }
    }
}
