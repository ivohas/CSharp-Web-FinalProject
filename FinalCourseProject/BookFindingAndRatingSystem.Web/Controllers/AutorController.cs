using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        private readonly IAutorService autorService;
        public AutorController(IAutorService autorService)
        {
            this.autorService = autorService;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllAutorViewModel> allAuthors;
            try
            {
                allAuthors = await autorService.GetAllAutorsAsync();
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
                author = await this.autorService.GetAutorByIdAsync(id);
            }
            catch (Exception)
            {
                return this.BadRequest("We could not find author with this id, please try again later!");
            }

            return View(author);
        }
    }
}
