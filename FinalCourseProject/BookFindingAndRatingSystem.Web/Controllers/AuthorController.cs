using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.NotificationMessagesConstants;

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
                TempData[ErrorMessage] = "Something went wrong. Please try again later.";
                return RedirectToAction(nameof(Index), "Home"); // Adjust this redirection as needed
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
                TempData[ErrorMessage] = "We could not find the author with this ID. Please try again later.";
                return RedirectToAction(nameof(All));
            }

            return View(author);
        }
    }
}
