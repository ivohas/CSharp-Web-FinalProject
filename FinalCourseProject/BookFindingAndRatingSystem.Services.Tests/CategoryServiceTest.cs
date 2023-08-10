using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BookFindingAndRatingSystem.Services.Tests
{
    [TestFixture]
    public class CategoryServiceTests
    {
        private DbContextOptions<BooksDbContext> _dbOptions;
        private BooksDbContext _dbContext;
        private ICategoryService _categoryService;
        private Mock<ILogger<CategoryService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("Test_Database")
                .Options;
            _dbContext = new BooksDbContext(_dbOptions);

            _mockLogger = new Mock<ILogger<CategoryService>>();
            _categoryService = new CategoryService(_mockLogger.Object, _dbContext);
        }

        [Test]
        public async Task AllCategoriesNameAsync_ReturnsAllCategoryNames()
        {
            var categories = new List<Category>
            {
                new Category { Name = "Fiction" },
                new Category { Name = "Non-Fiction" },
                new Category { Name = "Mystery" }
            };
            _dbContext.Categories.AddRange(categories);
            await _dbContext.SaveChangesAsync();

            var result = await _categoryService.AllCategoriesNameAsync();
            var expectedResult = categories.Select(c => c.Name);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task AllCategoriesNameAsync_ExceptionOccurs_ThrowsException()
        {
            _dbContext.Dispose(); // Dispose the context to simulate an exception

            Assert.ThrowsAsync<ObjectDisposedException>(async () =>
            {
                await _categoryService.AllCategoriesNameAsync();
            });
        }
    }
}
