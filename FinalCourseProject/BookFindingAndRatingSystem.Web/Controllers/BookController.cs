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
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<AllBookViewModel> viewModel =
                await this.bookService.AllBooksAsync();

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            DetailsBookViewModel bookViewModel = await bookService.GetBookByIdAsync(id.ToString());

            if (bookViewModel != null)
            {
                return View(bookViewModel);
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> PopularBooks() 
        {
            IEnumerable<AllBookViewModel> popularBooks = await 
                this.bookService.GetBooksByNumberOfSellsAsync();
            return View(popularBooks);
        }
        [HttpGet]
        public async Task<IActionResult> AutorsBook(int id)
        {

            IEnumerable<AllBookViewModel> autorsBooks = await
                this.bookService.GetAllAutorsBookByIdAsync(id.ToString());

            return View(autorsBooks);
        }
        [HttpGet]
        public async Task<IActionResult> WantToRead(int id)
        {
            var book = await this.bookService.GetBookByIdAsync(id.ToString());

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = this.GetUserId();

            await this.bookService.AddBookToUserByIdAsync(userId, book);

            return View(book);
            // Add view 
        }
    }
}
