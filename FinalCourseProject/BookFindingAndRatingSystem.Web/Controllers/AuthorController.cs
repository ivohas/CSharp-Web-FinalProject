using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
namespace BookFindingAndRatingSystem.Web.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        public AuthorController(IAuthorService autorService)
        {
            this.authorService = autorService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllAutorViewModel> allAuthors;
            try
            {
                allAuthors = await authorService.GetAllAutorsAsync();
            }
            catch (Exception)
            {
                return this.BadRequest("Something went wrong try again later!");
            }

            return View(allAuthors);
        }
        public async Task<IActionResult> Details(string id)
        {
            AllAutorViewModel? author;
            try
            {
                author = await this.authorService.GetAutorByIdAsync(id);
            }
            catch (Exception)
            {
                return this.BadRequest("We could not find author with this id, please try again later!");
            }

            return View(author);
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

            return RedirectToAction("Details", new { id = $"{model.Id}" });

        }
    }
}
