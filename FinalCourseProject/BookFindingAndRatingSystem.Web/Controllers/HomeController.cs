using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Library.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            this.bookService = bookService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AllBookViewModel> books;
            try
            {
                books = await this.bookService.GetBooksByNumberOfSellsAsync();
            }
            catch (Exception)
            {
                return this.BadRequest("Something went wrong");

            }

            books = books.Take(2).ToArray();

            return View(books);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return this.View("Error404");
            }
            if (statusCode == 401)
            {
                return this.View("Error401");
            }
            return this.View();
        }
    }
}