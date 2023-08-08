using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Library.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
using static BookFindingAndRatingSystem.Common.NotificationMessagesConstants;
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
            if (User.IsInRole(AdminRoleName))
            {
                TempData[InformationMessage] = "Admins are redirected to a different area.";
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            IEnumerable<AllBookViewModel> books;
            try
            {
                books = await this.bookService.GetBooksByNumberOfSellsAsync();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Something went wrong while fetching books.";
                return RedirectToAction("Error", new { statusCode = 400 });
            }

            books = books.Take(2).ToArray();

            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                TempData[ErrorMessage] = "Page not found or invalid request.";
                return View("Error404");
            }
            if (statusCode == 401)
            {
                TempData[ErrorMessage] = "Unauthorized access.";
                return View("Error401");
            }

            TempData[ErrorMessage] = "An error occurred.";
            return View();
        }
    }
}
