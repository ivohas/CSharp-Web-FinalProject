using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class UserService : IUserService
    {
        private readonly BooksDbContext dbContext;

        public UserService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddOrEditAboutForUserByIdAsync(string? userId, ProfileViewModel model)
        {
            var user = await this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefaultAsync();

            if (user != null)
            {
                user.About = model.About;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Problem occured in saving the info about you!");
            }

        }

        public async Task AddOrEditReadingChallengeAsync(string? userId, ProfileViewModel model)
        {
            var user = await this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefaultAsync();

            if (user != null)
            {
                user.ReadingChallenge = model.ReadingChalenge;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Problem occured in saving the info about you!");
            }
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            IEnumerable<UserViewModel> users; 
            try
            {
                 users = await this.dbContext
                            .Users
                            .Select(u => new UserViewModel
                            {
                                Email = u.Email,
                                PhoneNumber = u.PhoneNumber,
                                UserName = u.UserName

                            }).ToArrayAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return users;
        }

        public async Task ChangeImageUrl(string userId, ProfileViewModel model)
        {
            var user = await this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefaultAsync();

            if (user != null)
            {
                user.ImageUrl = model.ImageUrl;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Problem occured in saving the info about you!");
            }
        }

        public async Task EditUserNameAsync(string userId, ProfileViewModel model)
        {
            bool userNameAlreadyExist = await this.dbContext.Users.Where(u => u.UserName == model.UserName).AnyAsync();

            if (userNameAlreadyExist)
            {
                throw new ArgumentException("There is already user with this username!");
            }

            var user = await this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("Problem occured");
            }

            user.UserName = model.UserName;
            await dbContext.SaveChangesAsync();
        }

        public async Task<ProfileViewModel> GetInfoByIdAsync(string? userId)
        {
            var info = await this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefaultAsync();

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
                    ImageUrl = info.ImageUrl
                };

                return model;
            }
            throw new ArgumentException("There isn't any user with this id");
        }
    }
}
