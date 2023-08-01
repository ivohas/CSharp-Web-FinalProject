using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add()
        {
            var model = new AuthorViewModel();
            return View(model);
        }
        [HttpPost]
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
                return BadRequest("Couldn't save the new book");
            }


            return RedirectToAction(nameof(All));
        }
    }
}
