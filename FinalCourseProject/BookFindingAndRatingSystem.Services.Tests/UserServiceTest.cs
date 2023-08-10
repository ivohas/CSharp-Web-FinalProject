using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BookFindingAndRatingSystem.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        private DbContextOptions<BooksDbContext> _dbOptions;
        private BooksDbContext _dbContext;
        private IUserService _userService;
        private Mock<ILogger<UserService>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _dbOptions = new DbContextOptionsBuilder<BooksDbContext>()
                .UseInMemoryDatabase("Test_Database")
                .Options;
            _dbContext = new BooksDbContext(_dbOptions);

            _mockLogger = new Mock<ILogger<UserService>>();
            _userService = new UserService(_mockLogger.Object, _dbContext);
        }
       

        [Test]
        public async Task AddOrEditAboutForUserByIdAsync_UserDoesNotExist_ThrowsException()
        {
            Assert.ThrowsAsync<Exception>(async () =>
            {
                var model = new ProfileViewModel { About = "About Info" };
                await _userService.AddOrEditAboutForUserByIdAsync("1", model);
            });
        }

        // Add similar tests for other methods

        [Test]
        public async Task GetInfoByIdAsync_UserExists_ReturnsProfileViewModel()
        {
            var user = new AplicationUser
            {
                Id = Guid.NewGuid(),
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                UserName = "testuser",
                About = "About Info",
                ReadingChallenge = 3,
                ImageUrl = "image.jpg",
                BooksRead = 2
            };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var result = await _userService.GetInfoByIdAsync(user.Id.ToString());

            Assert.IsNotNull(result);
            Assert.AreEqual(user.Email, result.Email);
            Assert.AreEqual(user.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(user.UserName, result.UserName);
            // Add assertions for other properties
        }

        [Test]
        public async Task GetInfoByIdAsync_UserDoesNotExist_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await _userService.GetInfoByIdAsync("1");
            });
        }
    }
}
