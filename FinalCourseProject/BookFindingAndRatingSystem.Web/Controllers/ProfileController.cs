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
                TempData[ErrorMessage] = "Couldn't get the user info. Please try again later!";
                return RedirectToAction("Index", "Home");
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
            }
            var userId = this.GetUserId();
            try
            {
                await this.userService.AddOrEditAboutForUserByIdAsync(userId, model);
                TempData[SuccessMessage] = "Successful edited about!";
            }
            catch (Exception)
            {
                TempData[SuccessMessage] = "Couldn't edit your about due to an error!";
                return RedirectToAction(nameof(MyProfile));
            }


            return RedirectToAction(nameof(MyProfile));
        }
        [HttpGet]
        public async Task<IActionResult> ReadingChallange(Guid id)
        {
            ProfileViewModel user;
            try
            {
                user = await this.userService.GetInfoByIdAsync(id.ToString());
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't get the your reading challege. Please try again later!";
                return RedirectToAction(nameof(MyProfile));
            }


            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> ReadingChallange(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Invalid data";
                return View(model);
            }
            var userId = this.GetUserId();
            try
            {
                await this.userService.AddOrEditReadingChallengeAsync(userId, model);
                TempData[SuccessMessage] = "Successfully edited reading challenge!";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't save your reading challenge due to an error!";
                return View(model);
            }


            return RedirectToAction(nameof(MyProfile));
        }
        [HttpGet]
        public async Task<IActionResult> ChangeUserName(Guid id)
        {
            ProfileViewModel model;
            try
            {
                model = await this.userService.GetInfoByIdAsync(id.ToString());
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't get the your username. Please try again later!";
                return RedirectToAction(nameof(MyProfile));
            }

            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserName(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Invalid data";
                return View(model);
            }
            try
            {
                await this.userService.EditUserNameAsync(this.GetUserId()!, model);
                TempData[SuccessMessage] = "Successfully changed username!";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't save your username due to an error!";
                return View(model);
            }

            return RedirectToAction(nameof(MyProfile));
        }
        [HttpGet]
        public async Task<IActionResult> ChangeImage(Guid id)
        {
            ProfileViewModel model;
            try
            {
                model = await this.userService.GetInfoByIdAsync(id.ToString());
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't get the your image. Please try again later!";
                return RedirectToAction(nameof(MyProfile));
            }


            return this.View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeImage(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Invalid data";
                return View(model);
            }
            try
            {
                await this.userService.ChangeImageUrl(this.GetUserId()!, model);
                TempData[SuccessMessage] = "Successfully changed image!";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Couldn't save your username due to an error!";
                return View(model);
            }

            return RedirectToAction(nameof(MyProfile));
        }
    }
}
