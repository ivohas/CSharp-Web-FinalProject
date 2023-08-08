using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using Library.Controllers;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.NotificationMessagesConstants;
namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IUserService userService;
        public ProfileController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> MyProfile()
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
            ProfileViewModel user;
            try
            {
                user = await this.userService.GetInfoByIdAsync(id.ToString());
            }
            catch (Exception)
            {

                throw;
            }


            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditAbout(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "You entered invalid data!";
                return View(model);
                //return BadRequest("Invalid data!");
            }
            var userId = this.GetUserId();
            try
            {
                await this.userService.AddOrEditAboutForUserByIdAsync(userId, model);
                TempData[SuccessMessage] = "Successful edited about!";
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction(nameof(MyProfile));
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data!");
            }
            var userId = this.GetUserId();
            await this.userService.AddOrEditReadingChallengeAsync(userId, model);

            return RedirectToAction(nameof(MyProfile));
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data!");
            }
            try
            {
                await this.userService.EditUserNameAsync(this.GetUserId()!, model);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(MyProfile));
        }
        [HttpGet]
        public async Task<IActionResult> ChangeImage(Guid id)
        {

            var model = await this.userService.GetInfoByIdAsync(id.ToString());

            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeImage(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data!");
            }
            try
            {
                await this.userService.ChangeImageUrl(this.GetUserId()!, model);
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(MyProfile));
        }
    }
}
