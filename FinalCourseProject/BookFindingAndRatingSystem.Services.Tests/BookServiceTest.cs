using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;


namespace BookFindingAndRatingSystem.Services.Tests
{
    using static DatabaseSeeder;
    public class BookServiceTest
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
    }
}
