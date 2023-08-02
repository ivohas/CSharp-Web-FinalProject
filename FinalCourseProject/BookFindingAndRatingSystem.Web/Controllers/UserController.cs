using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using Library.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> Profile()
        {

            var userId = this.GetUserId();
            ProfileViewModel model;
            try
            {
                model = await this.userService.GetInfoByIdAsync(userId);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditAbout(Guid id)
        {
            var user = await this.userService.GetInfoByIdAsync(id.ToString());

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditAbout(ProfileViewModel model)
        {
            var userId = this.GetUserId();
            await this.userService.AddOrEditAboutForUserByIdAsync(userId, model);

            return RedirectToAction(nameof(Profile));
        }
        [HttpGet]
        public async Task<IActionResult> ReadingChallange(Guid id)
        {
            var user = await this.userService.GetInfoByIdAsync(id.ToString());

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ReadingChallange(ProfileViewModel model)
        {
            var userId = this.GetUserId();
            await this.userService.AddOrEditReadingChallengeAsync(userId, model);

            return RedirectToAction(nameof(Profile));
        }
        [HttpGet]
        public async Task<IActionResult> ChangeUserName(Guid id)
        {
            var model = await this.userService.GetInfoByIdAsync(id.ToString());
            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserName(ProfileViewModel model)
        {
            try
            {
                await this.userService.EditUserNameAsync(this.GetUserId()!, model);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Profile));
        }
        // Change username where you check if it used already
    }
}
