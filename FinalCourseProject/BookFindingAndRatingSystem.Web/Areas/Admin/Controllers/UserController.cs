using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> model;
            try
            {
                model = await this.userService.AllAsync();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            return View(model);
        }
    }
}
