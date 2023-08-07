using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookFindingAndRatingSystem.Services.Tests
{
    using static DatabaseSeeder;
    public class AuhtorServiceTests
    {
        private DbContextOptions<BooksDbContext> dbOptions;
        private BooksDbContext dbContext;
        private IAuthorService authorService;
        private Mock<ILogger<AuthorService>> mockLogger;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("BookRentingInMemory" + Guid.NewGuid().ToString()).Options;
            this.dbContext = new BooksDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            // Create a mock logger
            this.mockLogger = new Mock<ILogger<AuthorService>>();

            // Use the mock logger in the AuthorService
            this.authorService = new AuthorService(this.dbContext, mockLogger.Object);
        }

        [SetUp]
        public void Setup()
        {


            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            SeedDatabase(dbContext);
            dbContext.ChangeTracker.Clear();

        }
        [Test]
        public void CreateNewAuthorAsync_ShouldLogInformation()
        {
            // Arrange
            var model = new AuthorViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Parse("1990-01-01"),
                ImageUrl = "author_image_url"
            };

            // Act
            authorService.CreateNewAuthorAsync(model).Wait();

            // Assert
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("New author created:", o.ToString(), StringComparison.OrdinalIgnoreCase)),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }

        [Test]
        public void EditAuthorAsync_ShouldLogInformation()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();
            var model = new AuthorViewModel
            {
                Id = existingAuthor.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                BirthDate = DateTime.Parse("1985-01-01"),
                ImageUrl = "updated_author_image_url"
            };

            // Act
            authorService.EditAuthorAsync(model).Wait();

            // Assert
            mockLogger.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((o, t) => string.Equals("Author edited:", o.ToString(), StringComparison.OrdinalIgnoreCase)),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()
                ),
                Times.Once
            );
        }
        [Test]
        public async Task GetAutorByIdAsyncShouldBeSame()
        {
            string id = author.Id.ToString();
            var result = await this.authorService.GetAutorByIdAsync(id);
            AllAutorViewModel model = new AllAutorViewModel
            {
                Id = result.Id,
                LastName = result.LastName,
                FirstName = result.FirstName,
                ImageUrl = result.ImageUrl,
                BirthDate = result.BirthDate
            };

            Assert.AreEqual(result.ImageUrl, model.ImageUrl);
            Assert.AreEqual(result.BirthDate, model.BirthDate);
            Assert.AreEqual(result.FirstName, model.FirstName);
            Assert.AreEqual(result.LastName, model.LastName);
            Assert.AreEqual(result.Id, model.Id);
        }
        [Test]
        public async Task GetAutorByIdAsyncShouldntBeSame()
        {
            string id = author2.Id.ToString();
            var result = await this.authorService.GetAutorByIdAsync(id);
            AllAutorViewModel model = new AllAutorViewModel
            {
                Id = author.Id,
                LastName = author.LastName,
                FirstName = author.FirstName,
                ImageUrl = author.ImageUrl,
                BirthDate = author.BirthDate
            };
            Assert.AreNotEqual(result, model);
        }
        [Test]
        public async Task GetAllAutorsAsyncReturnsRightAuthorsCount()
        {

            var result = await this.authorService.GetAllAutorsAsync();
            var lenght = result.Count();
            Assert.AreEqual(lenght, this.dbContext.Autors.Count());
        }
        [Test]
        public async Task EditAuthorAsync_ShouldEditAuthor()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();
            var model = new AuthorViewModel
            {
                Id = existingAuthor.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                BirthDate = DateTime.Parse("1985-01-01"),
                ImageUrl = "updated_author_image_url"
            };

            // Act
            await authorService.EditAuthorAsync(model);

            // Assert
            var editedAuthor = await dbContext.Autors.FindAsync(existingAuthor.Id);
            Assert.AreEqual(model.FirstName, editedAuthor.FirstName);
            Assert.AreEqual(model.LastName, editedAuthor.LastName);
            Assert.AreEqual(model.BirthDate, editedAuthor.BirthDate);
            Assert.AreEqual(model.ImageUrl, editedAuthor.ImageUrl);
        }

        [Test]
        public async Task CreateNewAuthorAsync_ShouldCreateNewAuthor()
        {
            // Arrange
            var model = new AuthorViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Parse("1990-01-01"),
                ImageUrl = "author_image_url"
            };

            // Act
            await authorService.CreateNewAuthorAsync(model);

            // Assert
            var createdAuthor = await dbContext.Autors.FirstOrDefaultAsync(a => a.FirstName == model.FirstName && a.LastName == model.LastName);
            Assert.NotNull(createdAuthor);
        }

        [Test]
        public async Task GetAllAutorsAsync_ReturnsCorrectAuthors()
        {
            // Arrange

            // Act
            var result = await authorService.GetAllAutorsAsync();

            // Assert
            var expectedAuthorsCount = dbContext.Autors.Count();
            Assert.AreEqual(expectedAuthorsCount, result.Count());
        }

        [Test]
        public async Task GetAllAutorsBookAsync_ReturnsCorrectBooksForAuthor()
        {
            // Arrange
            var authorId = dbContext.Autors.First().Id.ToString();

            // Act
            var result = await authorService.GetAllAutorsBookAsync(authorId);

            // Assert
            var author = await dbContext.Autors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id.ToString() == authorId);
            var expectedBooksCount = author?.Books?.Count ?? 0;
            Assert.AreEqual(expectedBooksCount, result.Count());
        }

        [Test]
        public async Task GetAuthorForEditByIdAsync_ReturnsCorrectAuthor()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();

            // Act
            var result = await authorService.GetAuthorForEditByIdAsync(existingAuthor.Id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(existingAuthor.FirstName, result.FirstName);
            Assert.AreEqual(existingAuthor.LastName, result.LastName);
            Assert.AreEqual(existingAuthor.BirthDate, result.BirthDate);
            Assert.AreEqual(existingAuthor.ImageUrl, result.ImageUrl);
        }

        [Test]
        public async Task GetAutorByIdAsync_ReturnsCorrectAuthor()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();

            // Act
            var result = await authorService.GetAutorByIdAsync(existingAuthor.Id.ToString());

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(existingAuthor.FirstName, result.FirstName);
            Assert.AreEqual(existingAuthor.LastName, result.LastName);
            Assert.AreEqual(existingAuthor.BirthDate, result.BirthDate);
            Assert.AreEqual(existingAuthor.ImageUrl, result.ImageUrl);
        }
        [Test]
        public async Task GetAllAutorsBookAsync_ReturnsEmptyListForInvalidAuthorId()
        {
            // Arrange
            string invalidAuthorId = "invalid_id";

            // Act
            var result = await authorService.GetAllAutorsBookAsync(invalidAuthorId);

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetAuthorForEditByIdAsync_ReturnsNullForInvalidAuthorId()
        {
            // Arrange
            int invalidAuthorId = -1;

            // Act and Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await authorService.GetAuthorForEditByIdAsync(invalidAuthorId));
            Assert.AreEqual("Author not found", exception.Message);
        }


        [Test]
        public async Task GetAutorByIdAsync_ReturnsNullForInvalidAuthorId()
        {
            // Arrange
            string invalidAuthorId = "invalid_id";

            // Act
            var result = await authorService.GetAutorByIdAsync(invalidAuthorId);

            // Assert
            Assert.Null(result);
        }
        [Test]
        public async Task CreateNewAuthorAsync_CreatesNewAuthor()
        {
            // Arrange
            var model = new AuthorViewModel
            {
                FirstName = "John",
                LastName = "Doe",
                BirthDate = DateTime.Parse("1990-01-01"),
                ImageUrl = "author_image_url"
            };

            // Act
            await authorService.CreateNewAuthorAsync(model);

            // Assert
            var createdAuthor = await dbContext.Autors.FirstOrDefaultAsync(a => a.FirstName == model.FirstName && a.LastName == model.LastName);
            Assert.NotNull(createdAuthor);
        }

        [Test]
        public async Task EditAuthorAsync_UpdatesExistingAuthor()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();
            var model = new AuthorViewModel
            {
                Id = existingAuthor.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                BirthDate = DateTime.Parse("1985-01-01"),
                ImageUrl = "updated_author_image_url"
            };

            // Act
            await authorService.EditAuthorAsync(model);

            // Assert
            var editedAuthor = await dbContext.Autors.FindAsync(existingAuthor.Id);
            Assert.AreEqual(model.FirstName, editedAuthor.FirstName);
            Assert.AreEqual(model.LastName, editedAuthor.LastName);
            Assert.AreEqual(model.BirthDate, editedAuthor.BirthDate);
            Assert.AreEqual(model.ImageUrl, editedAuthor.ImageUrl);
        }

        [Test]
        public async Task GetAutorByIdAsync_ReturnsNullForInvalidAuthorIdTest()
        {
            // Arrange
            string invalidAuthorId = "invalid_id";

            // Act
            var result = await authorService.GetAutorByIdAsync(invalidAuthorId);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task GetAllAutorsAsync_ReturnsEmptyListWhenNoAuthorsExist()
        {
            // Arrange
            dbContext.Autors.RemoveRange(dbContext.Autors);
            await dbContext.SaveChangesAsync();

            // Act
            var result = await authorService.GetAllAutorsAsync();

            // Assert
            Assert.IsEmpty(result);
        }
        [Test]
        public async Task FetchAuthorWithBooks()
        {
            // Arrange
            var author = dbContext.Autors.Include(a => a.Books).FirstOrDefault(); // Fetch an author with books

            // Assert
            Assert.IsNotNull(author);
            Assert.IsNotNull(author.Books);
            Assert.IsNotEmpty(author.Books);
        }


        [Test]
        public async Task GetAllAutorsBookAsync_ReturnsEmptyListForAuthorWithNoBooks()
        {
            // Arrange
            var authorWithNoBooks = dbContext.Autors.First(a => a.Books.Count == 0);

            // Act
            var result = await authorService.GetAllAutorsBookAsync(authorWithNoBooks.Id.ToString());

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task CreateNewAuthorAsync_CreatesNewAuthorWithoutBooks()
        {
            // Arrange
            var model = new AuthorViewModel
            {
                FirstName = "New",
                LastName = "Author",
                BirthDate = DateTime.Parse("1995-01-01"),
                ImageUrl = "new_author_image_url"
            };

            // Act
            await authorService.CreateNewAuthorAsync(model);

            // Assert
            var createdAuthor = await dbContext.Autors.FirstOrDefaultAsync(a => a.FirstName == model.FirstName && a.LastName == model.LastName);
            Assert.NotNull(createdAuthor);
            Assert.IsEmpty(createdAuthor.Books); // New author should not have books
        }
        [Test]
        public async Task GetAllAutorsAsync_ReturnsDistinctAuthors()
        {
            // Arrange
            // Seed database with authors

            // Act
            var result = await authorService.GetAllAutorsAsync();

            // Assert
            var distinctAuthors = result.GroupBy(a => a.Id).Select(group => group.First());
            Assert.AreEqual(result.Count(), distinctAuthors.Count());
        }

        [Test]
        public async Task GetAuthorForEditByIdAsync_ReturnsNullForNonexistentAuthor()
        {
            // Arrange
            int nonexistentAuthorId = 9999;

            // Act and Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await authorService.GetAuthorForEditByIdAsync(nonexistentAuthorId));
            Assert.AreEqual("Author not found", exception.Message);
        }

        [Test]
        public async Task EditAuthorAsync_DoesNotModifyOtherAuthors()
        {
            // Arrange
            var existingAuthor = dbContext.Autors.First();
            var model = new AuthorViewModel
            {
                Id = existingAuthor.Id,
                FirstName = "UpdatedFirstName",
                LastName = "UpdatedLastName",
                BirthDate = DateTime.Parse("1985-01-01"),
                ImageUrl = "updated_author_image_url"
            };

            // Act
            await authorService.EditAuthorAsync(model);

            // Assert
            var otherAuthors = await dbContext.Autors.Where(a => a.Id != existingAuthor.Id).ToListAsync();
            foreach (var author in otherAuthors)
            {
                Assert.AreNotEqual(model.FirstName, author.FirstName);
                Assert.AreNotEqual(model.LastName, author.LastName);
                Assert.AreNotEqual(model.BirthDate, author.BirthDate);
                Assert.AreNotEqual(model.ImageUrl, author.ImageUrl);
            }
        }

    }
}