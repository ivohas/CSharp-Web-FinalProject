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

        public async Task<IActionResult> All()
        {
            IEnumerable<AllAutorViewModel> allAutors = await autorService.GetAllAutorsAsync();
            return View(allAutors);
        }

        public async Task<IActionResult> Details(string id)
        {
           
            AllAutorViewModel autor = await this.autorService.GetAutorByIdAsync(id);
            return View(autor);
        }
    }
}
