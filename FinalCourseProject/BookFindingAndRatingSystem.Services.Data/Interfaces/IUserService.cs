﻿using BookFindingAndRatingSystem.ViewModels;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<ProfileViewModel> GetInfoByIdAsync(string? userId);
        Task AddOrEditAboutForUserByIdAsync(string? userId, ProfileViewModel model);
    }
}
