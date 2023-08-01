﻿using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;

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
            var user = this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefault();

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
            var user = this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefault();

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

        public Task<ProfileViewModel> GetInfoByIdAsync(string? userId)
        {
            var info = this.dbContext.Users.Where(x => x.Id.ToString() == userId).FirstOrDefault();

            if (info != null)
            {
                var model = new ProfileViewModel()
                {
                    Id = info.Id,
                    Email = info.Email,
                    PhoneNumber = info.PhoneNumber,
                    UserName = info.UserName,
                    About = info.About,
                    ReadingChalenge = info.ReadingChallenge                   
                };

                return Task.FromResult(model);
            }
            throw new ArgumentException("There isn't any user with this id");
        }
    }
}
