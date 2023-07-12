using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Library.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    [Authorize]
    public class BookController : BaseController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }
       
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBookViewModel> viewModel =
                await this.bookService.AllBooksAsync();

            return View(viewModel);
        }
    }
}
