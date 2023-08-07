using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Tests
{
    using static DatabaseSeeder;
    public class AuhtorServiceTests
    {
        private DbContextOptions<BooksDbContext> dbOptions;
        private BooksDbContext dbContext;
        private IAuthorService authorService;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("BookRentingInMamory" + Guid.NewGuid().ToString()).Options;
            this.dbContext = new BooksDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.authorService = new AuthorService(this.dbContext);
        }

        [SetUp]
        public void Setup()
        {
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
            Assert.AreEqual(result.Id , model.Id );
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
    }
}