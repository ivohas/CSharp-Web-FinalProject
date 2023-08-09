using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace BookFindingAndRatingSystem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly BooksDbContext _dbContext;

        public UserService(ILogger<UserService> logger, BooksDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task AddOrEditAboutForUserByIdAsync(string? userId, ProfileViewModel model)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

                if (user != null)
                {
                    user.About = model.About;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Problem occurred while saving the info about you!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving About info for user.");
                throw; // Rethrow the exception
            }
        }

        public async  Task AddOrEditBooksReadAsync(string? userId, ProfileViewModel model)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

                if (user != null)
                {
                    user.BooksRead = model.BookRead;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Problem occurred while saving the info about you!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving Reading Challenge for user.");
                throw; // Rethrow the exception
            }
        }

        public async Task AddOrEditReadingChallengeAsync(string? userId, ProfileViewModel model)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

                if (user != null)
                {
                    user.ReadingChallenge = model.ReadingChalenge;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Problem occurred while saving the info about you!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving Reading Challenge for user.");
                throw; // Rethrow the exception
            }
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            try
            {
                IEnumerable<UserViewModel> users = await _dbContext.Users
                    .Select(u => new UserViewModel
                    {
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        UserName = u.UserName
                    })
                    .ToArrayAsync();

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all users.");
                throw; // Rethrow the exception
            }
        }

        public async Task ChangeImageUrl(string userId, ProfileViewModel model)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

                if (user != null)
                {
                    user.ImageUrl = model.ImageUrl;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Problem occurred while saving the info about you!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while changing Image URL for user.");
                throw; // Rethrow the exception
            }
        }

        public async Task EditUserNameAsync(string userId, ProfileViewModel model)
        {
            try
            {
                bool userNameAlreadyExist = await _dbContext.Users
                    .Where(u => u.UserName == model.UserName)
                    .AnyAsync();

                if (userNameAlreadyExist)
                {
                    throw new ArgumentException("There is already a user with this username!");
                }

                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
                if (user == null)
                {
                    throw new Exception("Problem occurred.");
                }

                user.UserName = model.UserName;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing username for user.");
                throw; // Rethrow the exception
            }
        }

        public async Task<ProfileViewModel> GetInfoByIdAsync(string? userId)
        {
            try
            {
                var info = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);

                if (info != null)
                {
                    var model = new ProfileViewModel()
                    {
                        Id = info.Id,
                        Email = info.Email,
                        PhoneNumber = info.PhoneNumber,
                        UserName = info.UserName,
                        About = info.About,
                        ReadingChalenge = info.ReadingChallenge,
                        ImageUrl = info.ImageUrl,
                        BookRead = info.BooksRead
                    };

                    return model;
                }

                throw new ArgumentException("There isn't any user with this id");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting user info by id.");
                throw; // Rethrow the exception
            }
        }
    }
}
