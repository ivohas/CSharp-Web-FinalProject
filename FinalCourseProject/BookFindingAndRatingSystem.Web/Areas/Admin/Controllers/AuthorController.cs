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
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await this.authorService.GetAuthorForEditByIdAsync(id);

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(AuthorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data!");
            }
            try
            {
                await this.authorService.EditAuthorAsync(model);
            }
            catch (Exception)
            {
                return this.BadRequest("The book can't be edited");
            }

            return RedirectToAction("Details", new { id = $"{model.Id}", area = ""});

        }
    }
}
