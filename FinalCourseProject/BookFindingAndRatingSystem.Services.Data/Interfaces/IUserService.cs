using BookFindingAndRatingSystem.ViewModels;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IUserService
    {
        Task<ProfileViewModel> GetInfoByIdAsync(string? userId);
        Task AddOrEditAboutForUserByIdAsync(string? userId, ProfileViewModel model);
        Task AddOrEditReadingChallengeAsync(string? userId, ProfileViewModel model);
        Task EditUserNameAsync(string v, ProfileViewModel model);
        Task ChangeImageUrl(string v, ProfileViewModel model);
    }
}
