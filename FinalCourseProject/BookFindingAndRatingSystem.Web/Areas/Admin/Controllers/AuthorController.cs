using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
namespace BookFindingAndRatingSystem.Web.Areas.Admin.Controllers
{
    public class AuthorController : BaseAdminController
    {
        private IAuthorService authorService;
        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            var model = new AuthorViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(AuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model", "Invalid data");
                return this.View(model);
            }
            try
            {
                await this.authorService.CreateNewAuthorAsync(model);
            }
            catch (Exception)
            {
                return BadRequest("Couldn't save the new auhtor");
            }


            return RedirectToAction("All", "Author", new { area = "" });

        }
    }
}
