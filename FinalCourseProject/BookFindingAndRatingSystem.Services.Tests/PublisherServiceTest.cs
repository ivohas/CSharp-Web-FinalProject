using System;
using System.Threading.Tasks;
using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Publisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BookFindingAndRatingSystem.Services.Tests
{
    [TestFixture]
    public class PublisherServiceTests
    {
        private DbContextOptions<BooksDbContext> _dbOptions;
        private BooksDbContext _dbContext;
        private IPublisherService _publisherService;
        private Mock<ILogger<PublisherService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("Test_Database")
                .Options;
            _dbContext = new BooksDbContext(_dbOptions);

            _mockLogger = new Mock<ILogger<PublisherService>>();
            _publisherService = new PublisherService(_mockLogger.Object, _dbContext);
        }

        [Test]
        public async Task CreateNewPublisher_ValidData_CreatesNewPublisher()
        {
            // Arrange
            var publisherName = "Test Publisher";
            var addPublisherViewModel = new AddPublisherViewModel
            {
                Name = publisherName
            };

            // Act
            await _publisherService.CreateNewPublisher(addPublisherViewModel);

            // Assert
            var createdPublisher = await _dbContext.Publishers.FirstOrDefaultAsync(p => p.Name == publisherName);
            Assert.NotNull(createdPublisher);
            Assert.AreEqual(publisherName, createdPublisher.Name);
        }

        [Test]
        public async Task CreateNewPublisher_DuplicateName_ThrowsException()
        {
            // Arrange
            var existingPublisher = new Publisher
            {
                Name = "Existing Publisher"
            };
            _dbContext.Publishers.Add(existingPublisher);
            await _dbContext.SaveChangesAsync();

            var duplicatePublisherName = "Existing Publisher";
            var addDuplicatePublisherViewModel = new AddPublisherViewModel
            {
                Name = duplicatePublisherName
            };

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () =>
            {
                await _publisherService.CreateNewPublisher(addDuplicatePublisherViewModel);
            });
        }       

        [Test]
        public async Task SaveChangesAsync_ValidData_SavesChanges()
        {
            var publisherName = "Test Publisher";
            var addPublisherViewModel = new AddPublisherViewModel
            {
                Name = publisherName
            };
            var newPublisher = new Publisher
            {
                Name = publisherName
            };
            _dbContext.Publishers.Add(newPublisher);
            await _dbContext.SaveChangesAsync();

           
            var savedPublisher = await _dbContext.Publishers.FirstOrDefaultAsync(p => p.Name == publisherName);
            Assert.NotNull(savedPublisher);
            Assert.AreEqual(publisherName, savedPublisher.Name);
        }
    }
}
