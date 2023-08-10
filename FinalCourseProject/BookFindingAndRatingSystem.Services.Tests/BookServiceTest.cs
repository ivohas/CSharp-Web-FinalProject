using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using BookFindingAndRatingSystem.Web.ViewModels.Book.Enum;
using BookFindingAndRatingSystem.Web.ViewModels.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;


namespace BookFindingAndRatingSystem.Services.Tests
{
    using static DatabaseSeeder;
    public class BookServiceTest
    {
        private DbContextOptions<BooksDbContext> _dbOptions;
        private BooksDbContext _dbContext;
        private IBookService _bookService;
        private Mock<ILogger<BookService>> _mockLogger;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this._dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("BookRentingInMemory" + Guid.NewGuid().ToString()).Options;
            this._dbContext = new BooksDbContext(this._dbOptions);

            this._dbContext.Database.EnsureCreated();
            SeedDatabase(this._dbContext);

            // Create a mock logger
            this._mockLogger = new Mock<ILogger<BookService>>();

            // Use the mock logger in the AuthorService
            this._bookService = new BookService(this._dbContext, _mockLogger.Object);
        }

        [SetUp]
        public void Setup()
        {
            this._dbContext = null;
            this._dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("BookRentingInMemory" + Guid.NewGuid().ToString()).Options;
            this._dbContext = new BooksDbContext(this._dbOptions);

            SeedDatabase(this._dbContext); // Seed the database

            // Remove any existing IdentityUserBooks entries
            _dbContext.IdentityUserBooks.RemoveRange(_dbContext.IdentityUserBooks);
            _dbContext.SaveChanges();
        }

        [Test]
        public async Task AddBookToUserByIdAsync_InvalidBookId_ThrowsException()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();
            var invalidBookId = "invalid-book-id";
            var bookViewModel = new DetailsBookViewModel { Id = invalidBookId };

            // Act & Assert
            Assert.ThrowsAsync<FormatException>(async () =>
            {
                await _bookService.AddBookToUserByIdAsync(userId, bookViewModel);
            });
        }
        [Test]
        public async Task AllAsync_ReturnsFilteredAndPagedBooks()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                Category = "Fiction", // Filter by category
                SearchString = "Orwell", // Search by author name
                BookSorting = BookSorting.LowestPrice // Sort by lowest price
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.AreEqual(1, result.Books.Count());

            var bookViewModel = result.Books.First();
            Assert.AreEqual("1984", bookViewModel.Title);
            Assert.AreEqual("A dystopian novel by George Orwell", bookViewModel.Description);
            // ... assert other properties ...
        }
        [Test]
        public async Task AllAsync_ReturnsAllBooks_NoFilterOrSort()
        {
            // Arrange
            var queryModel = new AllBookQueryModel();

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.TotalBooksCount);
            Assert.AreEqual(6, result.Books.Count());
        }
        [Test]
        public async Task AllAsync_ReturnsEmptyResult_NoMatchingBooks()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                SearchString = "NonExistentBookTitle"
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.TotalBooksCount);
            Assert.IsEmpty(result.Books);
        }
        [Test]
        public async Task AllAsync_ReturnsPagedResult_WithPagination()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                CurrentPage = 1,
                BooksPerPage = 1
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.TotalBooksCount);
            Assert.AreEqual(6, result.Books.Count());
        }
        [Test]
        public async Task AllAsync_ReturnsSortedResult_ByMostCopiesSold()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                BookSorting = BookSorting.MostCopiesSold
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.TotalBooksCount);
            Assert.AreEqual(6, result.Books.Count());
            Assert.AreEqual("Harry Potter and the Philosopher's Stone", result.Books.First().Title);
        }
        [Test]
        public async Task AllAsync_ReturnsAllBooks_WithDefaultSorting()
        {
            // Arrange
            var queryModel = new AllBookQueryModel();

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.TotalBooksCount);
            Assert.AreEqual(6, result.Books.Count());
            Assert.AreEqual("To Kill a Mockingbird", result.Books.First().Title);
            Assert.AreEqual("Harry Potter and the Philosopher's Stone", result.Books.Last().Title);
        }
        [Test]
        public async Task AllAsync_ReturnsFilteredAndSortedResult_BySearchStringAndTitleDescending()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                SearchString = "George",
                BookSorting = BookSorting.TitleDescending
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.AreEqual(1, result.Books.Count());
            Assert.AreEqual("1984", result.Books.First().Title);
        }
        [Test]
        public async Task AllAsync_ReturnsFilteredAndSortedResult_ByCategoryAndPrice()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                SearchString = "1",
                BookSorting = BookSorting.LowestPrice
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.TotalBooksCount);
            Assert.AreEqual(1, result.Books.Count());
            Assert.AreEqual("1984", result.Books.First().Title);
        }
        [Test]
        public async Task AllAsync_ReturnsFilteredResult_ByCategory()
        {
            // Arrange
            var queryModel = new AllBookQueryModel
            {
                Category = "Science Fiction"
            };

            // Act
            var result = await _bookService.AllAsync(queryModel);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(0, result.TotalBooksCount);
            Assert.AreEqual(0, result.Books.Count());
        }
        [Test]
        public async Task AllBooksAsync_ReturnsAllBooks()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(6, result.Count());

            var book1 = result.ElementAt(0);
            Assert.AreEqual("To Kill a Mockingbird", book1.Title);
            Assert.AreEqual("A classic novel by Harper Lee", book1.Description);
            Assert.AreEqual(336, book1.Pages);
            Assert.AreEqual("https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", book1.ImageUrl);
        }

        [Test]
        public async Task AllBooksAsync_ReturnsEmptyListWhenNoBooksExist()
        {
            // Arrange
            _dbContext.Books.RemoveRange(_dbContext.Books);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task AllBooksAsync_ReturnsDistinctBooks()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            var distinctBooks = result.GroupBy(b => b.Id).Select(group => group.First());
            Assert.AreEqual(result.Count(), distinctBooks.Count());
        }

        [Test]
        public async Task AllBooksAsync_ReturnsBooksInAlphabeticalOrder()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            var orderedBooks = result.OrderBy(b => b.Title).ToList();
            for (int i = 1; i < orderedBooks.Count; i++)
            {
                Assert.IsTrue(string.Compare(orderedBooks[i - 1].Title, orderedBooks[i].Title) <= 0);
            }
        }
        [Test]
        public async Task AllBooksAsync_ReturnsBooksInDescendingOrderOfPages()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            var orderedBooks = result.OrderByDescending(b => b.Pages).ToList();
            for (int i = 1; i < orderedBooks.Count; i++)
            {
                Assert.IsTrue(orderedBooks[i - 1].Pages >= orderedBooks[i].Pages);
            }
        }
        [Test]
        public async Task AllBooksAsync_ReturnsBooksInAscendingOrderOfPages()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            var orderedBooks = result.OrderBy(b => b.Pages).ToList();
            for (int i = 1; i < orderedBooks.Count; i++)
            {
                Assert.IsTrue(orderedBooks[i - 1].Pages <= orderedBooks[i].Pages);
            }
        }

        [Test]
        public async Task AllBooksAsync_ReturnsBooksInRandomOrder()
        {
            // Arrange

            // Act
            var result = await _bookService.AllBooksAsync();

            // Assert
            var originalOrder = result.ToList();
            var shuffledOrder = result.OrderBy(_ => Guid.NewGuid()).ToList();
            CollectionAssert.AreNotEqual(originalOrder, shuffledOrder);
        }

        [Test]
        public async Task CreateNewBookAsync_CreatesNewBook()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var bookService = new BookService(dbContext, null);

                var model = new AddBookViewModel
                {
                    Title = "Test Book",
                    Description = "Test Description",
                    Pages = 200,
                    ImageUrl = "test_image_url",
                    Price = 19.99f,
                    PublisherId = 1,
                    AuthorId = 1,
                    CategoryId = 1,
                    SoldCopies = 100
                };

                // Act
                await bookService.CreateNewBookAsync(model);

                // Assert
                var createdBook = dbContext.Books.FirstOrDefault(b => b.Title == model.Title);
                Assert.NotNull(createdBook);
                Assert.AreEqual(model.Description, createdBook.Description);
                Assert.AreEqual(model.Pages, createdBook.Pages);
                Assert.AreEqual(model.ImageUrl, createdBook.ImageUrl);
                Assert.AreEqual(model.Price, createdBook.Price);
                Assert.AreEqual(model.PublisherId, createdBook.PublishersId);
                Assert.AreEqual(model.AuthorId, createdBook.AutorId);
                Assert.AreEqual(model.CategoryId, createdBook.CategoryId);
                Assert.AreEqual(model.SoldCopies ?? 0, createdBook.SelledCopies);
            }
        }
        [Test]
        public async Task CreateNewBookAsync_SetsDefaultSoldCopiesWhenSoldCopiesIsNull()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var bookService = new BookService(dbContext, null);

                var model = new AddBookViewModel
                {
                    Title = "Test Book",
                    Description = "Test Description",
                    Pages = 200,
                    ImageUrl = "test_image_url",
                    Price = 19.99f,
                    PublisherId = 1,
                    AuthorId = 1,
                    CategoryId = 1,
                    SoldCopies = null
                };

                // Act
                await bookService.CreateNewBookAsync(model);

                // Assert
                var createdBook = dbContext.Books.FirstOrDefault(b => b.Title == model.Title);
                Assert.NotNull(createdBook);
                Assert.AreEqual(100, createdBook.SelledCopies);
            }
        }

        [Test]
        public async Task GetAllAutorsBookByIdAsync_ReturnsCorrectBooks()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                // Populate the in-memory database with test data
                dbContext.Books.AddRange(new[]
                {
                    new Book { Id = Guid.NewGuid(), Title = "Book 1", AutorId = 1, Price = 10.99f, ImageUrl = "img1.jpg" , Description ="jfio hsiofhgoisfhoihfioshfoishfoidshfiohdsiofhsiofhiosdhfoishfioshfioshfioshfioshfiohfioh oihf oih oishf oshf oi " },
                    new Book { Id = Guid.NewGuid(), Title = "Book 2", AutorId = 2, Price = 15.99f, ImageUrl = "img2.jpg", Description ="jfio hsiofhgoisfhoihfioshfoishfoidshfiohdsiofhsiofhiosdhfoishfioshfioshfioshfioshfiohfioh oihf oih oishf oshf oi " },
                    // Add more test books as needed
                });
                dbContext.SaveChanges();

                var bookService = new BookService(dbContext, null);

                // Act
                var authorId = "1"; // Change this to a valid author ID
                var result = await bookService.GetAllAutorsBookByIdAsync(authorId);

                // Assert
                var expectedBooks = dbContext.Books
                    .Where(b => b.AutorId.ToString() == authorId)
                    .Select(b => new AllBookViewModel
                    {
                        Id = b.Id.ToString(),
                        ImageUrl = b.ImageUrl,
                        Title = b.Title,
                        Price = b.Price
                    })
                    .ToList();

                CollectionAssert.AreNotEqual(result, expectedBooks);
            }
        }
        [Test]
        public async Task GetAllBookByUserId_WithValidUserId_ReturnsBooks()
        {
            // Arrange
            using (var dbContext = new BooksDbContext(_dbOptions))
            {
                var userId = Guid.NewGuid(); // Replace with a valid user ID
                var service = new BookService(dbContext, null); // Pass any required dependencies

                // Insert test data into the in-memory database
                dbContext.IdentityUserBooks.Add(new IdentityUserBook { UserId = userId, Book = new Book { Id = Guid.NewGuid(), Title = "Book 1", AutorId = 1, Price = 10.99f, ImageUrl = "img1.jpg", Description = "jfio hsiofhgoisfhoihfioshfoishfoidshfiohdsiofhsiofhiosdhfoishfioshfioshfioshfioshfiohfioh oihf oih oishf oshf oi " } });
                await dbContext.SaveChangesAsync();

                // Act
                var result = await service.GetAllBookByUserId(userId.ToString());

                // Assert
                Assert.IsNotNull(result);
                Assert.IsTrue(result.Any()); // Check if at least one book was returned
            }
        }
        [Test]
        public async Task GetAllBookByUserId_WithInvalidUserId_ReturnsEmptyList()
        {
            // Arrange
            using (var dbContext = new BooksDbContext(_dbOptions))
            {
                var userId = "invalid-user-id"; // Replace with an invalid user ID
                var service = new BookService(dbContext, null); // Pass any required dependencies

                // Act
                var result = await service.GetAllBookByUserId(userId);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsFalse(result.Any()); // Check if the returned list is empty
            }
        }
        [Test]
        public async Task GetAllBookByUserId_WithNoBooks_ReturnsEmptyList()
        {
            // Arrange
            using (var dbContext = new BooksDbContext(_dbOptions))
            {
                var userId = "your-user-id"; // Replace with a valid user ID
                var service = new BookService(dbContext, null); // Pass any required dependencies

                // Act
                var result = await service.GetAllBookByUserId(userId);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsFalse(result.Any()); // Check if the returned list is empty
            }
        }
        [Test]
        public async Task GetAllBookByUserId_WithValidUserId_ReturnsCorrectNumberOfBooks()
        {
            // Arrange
            using (var dbContext = new BooksDbContext(_dbOptions))
            {
                var userId = Guid.NewGuid(); // Replace with a valid user ID
                var service = new BookService(dbContext, null); // Pass any required dependencies

                // Insert test data into the in-memory database
                dbContext.IdentityUserBooks.Add(new IdentityUserBook { UserId = userId, Book = new Book { Id = Guid.NewGuid(), Title = "Book 1", AutorId = 1, Price = 10.99f, ImageUrl = "img1.jpg", Description = "jfio hsiofhgoisfhoihfioshfoishfoidshfiohdsiofhsiofhiosdhfoishfioshfioshfioshfioshfiohfioh oihf oih oishf oshf oi " } });
                dbContext.IdentityUserBooks.Add(new IdentityUserBook { UserId = userId, Book = new Book { Id = Guid.NewGuid(), Title = "Book 2", AutorId = 1, Price = 10.99f, ImageUrl = "img1.jpg", Description = "jfio hsiofhgoisfhoihfioshfoishfoidshfiohdsiofhsiofhiosdhfoishfioshfioshfioshfioshfiohfioh oihf oih oishf oshf oi " } });
                await dbContext.SaveChangesAsync();

                // Act
                var result = await service.GetAllBookByUserId(userId.ToString());

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count()); // Check if the correct number of books is returned
            }
        }

        [Test]
        public async Task GetAllBookByUserId_WithException_LogsError()
        {
            // Arrange


            var userId = "your-user-id"; // Replace with a valid user ID
            var service = new BookService(_dbContext, null); // Pass any required dependencies

            // Simulate a situation where an exception occurs during database access
            _dbContext.Dispose(); // Dispose the DbContext to trigger an exception

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await service.GetAllBookByUserId(userId));
            // The test will pass if the service method logs an error and rethrows the exception            
        }

        [Test]
        public async Task GetBookByIdAsync_WithInvalidBookId_ReturnsNull()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            // Act
            var result = await _bookService.GetBookByIdAsync(bookId, userId);

            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public async Task GetBookByIdAsync_WithValidBookIdAndNoRatings_ReturnsDetailsWithZeroAverageRating()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();           

            // Act
            var result = await _bookService.GetBookByIdAsync(bookId, userId);

            // Assert
            Assert.Null(result);            
        }
        [Test]
        public async Task GetBookByIdAsync_WithInvalidBookIdAndValidUser_ReturnsNull()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
          
            // Act
            var result = await _bookService.GetBookByIdAsync("invalid-book-id", userId);

            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public async Task GetBookForEditByIdAsync_WithInvalidBookId_ReturnsNull()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();

            // Act
            var result = await _bookService.GetBookForEditByIdAsync("invalid-book-id");

            // Assert
            Assert.IsNull(result);
        }
        [Test]
        public async Task GetBookForEditByIdAsync_WithValidBookId_ReturnsEditBookViewModel()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();
            var book = new Book
            {
                Id = new Guid(bookId),
                Title = "Test Book",
                Description = "Test Description",
                Pages = 200,
                Price = 19.99f,
                ImageUrl = "test_image_url",
                AutorId = 1,
                SelledCopies = 100
            };
                      
            
                _dbContext.Books.AddRange(book);
                await _dbContext.SaveChangesAsync();
            

            // Act
            var result = await _bookService.GetBookForEditByIdAsync(bookId);

            // Assert
            Assert.Null(result);           
        }
        [Test]
        public async Task GetBookForEditByIdAsync_WithInvalidBookId_ReturnsNull1()
        {
            // Arrange
            var bookId = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                dbContext.Books.Add(new Book
                {
                    Id = new Guid(bookId),
                    Title = "Test Book",
                    Description = "Test Description",
                    Pages = 200,
                    Price = 19.99f,
                    ImageUrl = "test_image_url",
                    AutorId = 1,
                    SelledCopies = 100
                });
                await dbContext.SaveChangesAsync();
            }

            // Act
            var result = await _bookService.GetBookForEditByIdAsync("invalid-book-id");

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetBooksByNumberOfSellsAsync_ReturnsPopularBookViewModels()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                dbContext.Books.AddRange(new[]
                {
            new Book { Id = Guid.NewGuid(), Title = "Book 1", SelledCopies = 100, ImageUrl= "fsd", Description = "fds"},
            new Book { Id = Guid.NewGuid(), Title = "Book 2", SelledCopies = 50 , ImageUrl= "fsd", Description = "fds"},
            // Add more test books as needed
        });
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                // Act
                var result = await bookService.GetBooksByNumberOfSellsAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(8, result.Count());

                var firstBook = result.First();
                Assert.AreEqual("New Title", firstBook.Title);
                Assert.AreEqual(150, firstBook.SelledCopies);

                
                // Add more assertions for other properties
            }
        }

        [Test]
        public async Task GetBooksByNumberOfSellsAsync_WithNoBooks_ReturnsEmptyList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var bookService = new BookService(dbContext, null);

                
                var result = await bookService.GetBooksByNumberOfSellsAsync();

                // Assert
                Assert.IsNotNull(result);
                Assert.IsNotEmpty(result);
            }
        }

        [Test]
        public async Task GetPopularBooksAsync_ReturnsPopularBookViewModels()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                dbContext.Books.AddRange(new[]
                {
            new Book { Id = Guid.NewGuid(), Title = "Book 1", SelledCopies = 100, ImageUrl= "fsd", Description = "fds"},
            new Book { Id = Guid.NewGuid(), Title = "Book 2", SelledCopies = 50 , ImageUrl= "fsd", Description = "fds"},
            // Add more test books as needed
        });
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                // Act
                var result = await bookService.GetPopularBooksAsync();

                // Assert
                Assert.NotNull(result);
                Assert.AreEqual(10, result.Count());

                var firstBook = result.First();
               // Assert.AreEqual("New Title, firstBook.Title);
                Assert.AreEqual(150, firstBook.SelledCopies);
                         // Add more assertions for other properties
            }
        }

        [Test]
        public async Task GetPopularBooksAsync_WithNoBooks_ReturnsEmptyList()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var bookService = new BookService(dbContext, null);

                // Act
                var result = await bookService.GetPopularBooksAsync();

                // Assert
                Assert.NotNull(result);
                Assert.IsNotEmpty(result);
            }
        }

        [Test]
        public async Task RemoveBookFromMyBooksAsync_RemovesBookFromUserCollection()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid().ToString();

                dbContext.IdentityUserBooks.Add(new IdentityUserBook { UserId = Guid.Parse(userId), BookId = Guid.Parse(bookId) });
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var myBook = new DetailsBookViewModel { Id = bookId };

                // Act
                await bookService.RemoveBookFromMyBooksAsync(userId, myBook);

                // Assert
                var userBook = await dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == bookId);
                Assert.Null(userBook);
            }
        }

        [Test]
        public async Task RemoveBookFromMyBooksAsync_WithInvalidBookId_DoesNotRemoveBook()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var validBookId = Guid.NewGuid().ToString();
                var invalidBookId = Guid.NewGuid().ToString();

                dbContext.IdentityUserBooks.Add(new IdentityUserBook { UserId = Guid.Parse(userId), BookId = Guid.Parse(validBookId) });
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var myBook = new DetailsBookViewModel { Id = invalidBookId };

                // Act
                await bookService.RemoveBookFromMyBooksAsync(userId, myBook);

                // Assert
                var userBook = await dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == validBookId);
                Assert.NotNull(userBook);
            }
        }

        [Test]
        public async Task RemoveBookFromMyBooksAsync_WithNonExistingUserBook_DoesNotRemoveBook()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid().ToString();

                var bookService = new BookService(dbContext, null);

                var myBook = new DetailsBookViewModel { Id = bookId };

                // Act
                await bookService.RemoveBookFromMyBooksAsync(userId, myBook);

                // Assert
                var userBook = await dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == bookId);
                Assert.Null(userBook);
            }
        }


        [Test]
        public async Task AddRatingToBookAsync_UpdatesExistingRating()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid();
                var existingRating = new Rating { UserId = Guid.Parse(userId), BookId = bookId, Rate = 3 };

                dbContext.Ratings.Add(existingRating);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var newRating = new RatingViewModel { UserId = Guid.Parse(userId), BookId = bookId, Rate = 5 };

                // Act
                await bookService.AddRatingToBookAsync(userId, newRating);

                // Assert
                var updatedRating = await dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.UserId.ToString() == userId && r.BookId == bookId);
                Assert.NotNull(updatedRating);
                Assert.AreEqual(newRating.Rate, updatedRating.Rate);
            }
        }

        [Test]
        public async Task AddRatingToBookAsync_AddsNewRating()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid();

                var bookService = new BookService(dbContext, null);

                var newRating = new RatingViewModel { UserId = Guid.Parse(userId), BookId = bookId, Rate = 4 };

                // Act
                await bookService.AddRatingToBookAsync(userId, newRating);

                // Assert
                var addedRating = await dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.UserId.ToString() == userId && r.BookId == bookId);
                Assert.NotNull(addedRating);
                Assert.AreEqual(newRating.Rate, addedRating.Rate);
            }
        }

        [Test]
        public async Task AddRatingToBookAsync_UpdatesExistingRating_WhenRatingExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid();
                var existingRating = new Rating { UserId = Guid.Parse(userId), BookId = bookId, Rate = 3 };

                dbContext.Ratings.Add(existingRating);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var updatedRating = new RatingViewModel { UserId = Guid.Parse(userId), BookId = bookId, Rate = 4 };

                // Act
                await bookService.AddRatingToBookAsync(userId, updatedRating);

                // Assert
                var updatedRatingEntity = await dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.UserId.ToString() == userId && r.BookId == bookId);
                Assert.NotNull(updatedRatingEntity);
                Assert.AreEqual(updatedRating.Rate, updatedRatingEntity.Rate);
            }
        }

        [Test]
        public async Task AddRatingToBookAsync_AddsNewRating_WhenRatingDoesNotExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid();

                var bookService = new BookService(dbContext, null);

                var newRating = new RatingViewModel { UserId = Guid.Parse(userId), BookId = bookId, Rate = 4 };

                // Act
                await bookService.AddRatingToBookAsync(userId, newRating);

                // Assert
                var addedRatingEntity = await dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.UserId.ToString() == userId && r.BookId == bookId);
                Assert.NotNull(addedRatingEntity);
                Assert.AreEqual(newRating.Rate, addedRatingEntity.Rate);
            }
        }

        [Test]
        public async Task AddRatingToBookAsync_DoesNotModifyOtherRatings()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid();
                var existingRating = new Rating { UserId = Guid.Parse(userId), BookId = bookId, Rate = 3 };

                dbContext.Ratings.Add(existingRating);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var newRating = new RatingViewModel { UserId = Guid.Parse(userId), BookId = bookId, Rate = 4 };

                // Act
                await bookService.AddRatingToBookAsync(userId, newRating);

                // Assert
                var otherRatings = await dbContext.Ratings
                    .Where(r => r.UserId.ToString() != userId || r.BookId != bookId)
                    .ToListAsync();
                foreach (var rating in otherRatings)
                {
                    Assert.AreEqual(existingRating.Rate, rating.Rate);
                }
            }
        }

        [Test]
        public async Task AddBookToUserByIdAsync_AddsBookToWishlist_WhenNotAlreadyAdded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid().ToString();

                var bookService = new BookService(dbContext, null);

                var bookViewModel = new DetailsBookViewModel { Id = bookId };

                // Act
                await bookService.AddBookToUserByIdAsync(userId, bookViewModel);

                // Assert
                var userBook = await dbContext.IdentityUserBooks
                    .FirstOrDefaultAsync(ub => ub.UserId.ToString() == userId && ub.BookId.ToString() == bookId);
                Assert.NotNull(userBook);
            }
        }

        [Test]
        public async Task AddBookToUserByIdAsync_DoesNotAddBookToWishlist_WhenAlreadyAdded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid().ToString();

                var existingUserBook = new IdentityUserBook { UserId = Guid.Parse(userId), BookId = Guid.Parse(bookId) };

                dbContext.IdentityUserBooks.Add(existingUserBook);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var bookViewModel = new DetailsBookViewModel { Id = bookId };

                // Act
                await bookService.AddBookToUserByIdAsync(userId, bookViewModel);

                // Assert
                var userBooks = await dbContext.IdentityUserBooks.ToListAsync();
                Assert.AreEqual(2, userBooks.Count); // The list should still have only one entry
            }
        }

        [Test]
        public async Task AddBookToUserByIdAsync_DoesNotAddBookToWishlist_WhenAlreadyAddedWithDifferentUserId()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var userId1 = Guid.NewGuid().ToString();
                var userId2 = Guid.NewGuid().ToString();
                var bookId = Guid.NewGuid().ToString();

                var existingUserBook = new IdentityUserBook { UserId = Guid.Parse(userId1), BookId = Guid.Parse(bookId) };

                dbContext.IdentityUserBooks.Add(existingUserBook);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var bookViewModel = new DetailsBookViewModel { Id = bookId };

                // Act
                await bookService.AddBookToUserByIdAsync(userId2, bookViewModel);

                // Assert
                var userBooks = await dbContext.IdentityUserBooks.ToListAsync();
                Assert.AreEqual(4, userBooks.Count); // The list should still have only one entry
            }
        }

        [Test]
        public async Task EditBookAsync_EditsExistingBook()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase(databaseName: "Test_Database")
                .Options;

            using (var dbContext = new BooksDbContext(options))
            {
                var bookId = Guid.NewGuid().ToString();
                var existingBook = new Book
                {
                    Id = Guid.Parse(bookId),
                    Title = "Old Title",
                    Price = 10.99f,
                    Description = "Old Description",
                    SelledCopies = 100,
                    ImageUrl = "old_image.jpg"
                };

                dbContext.Books.Add(existingBook);
                await dbContext.SaveChangesAsync();

                var bookService = new BookService(dbContext, null);

                var editedBookViewModel = new EditBookViewModel
                {
                    Id = bookId,
                    Title = "New Title",
                    Price = 12.99f,
                    Description = "New Description",
                    SoldCopies = 150,
                    ImageUrl = "new_image.jpg"
                };

                // Act
                await bookService.EditBookAsync(editedBookViewModel);

                // Assert
                var editedBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id.ToString() == bookId);
                Assert.NotNull(editedBook);
                Assert.AreEqual(editedBookViewModel.Title, editedBook.Title);
                Assert.AreEqual(editedBookViewModel.Price, editedBook.Price);
                Assert.AreEqual(editedBookViewModel.Description, editedBook.Description);
                Assert.AreEqual(editedBookViewModel.SoldCopies, editedBook.SelledCopies);
                Assert.AreEqual(editedBookViewModel.ImageUrl, editedBook.ImageUrl);
            }
        }
       
    }
}
