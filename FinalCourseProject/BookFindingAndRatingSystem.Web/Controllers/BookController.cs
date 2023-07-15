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

        public async Task<IActionResult> Details(Guid id)
        {
            DetailsBookViewModel bookViewModel = await bookService.GetBookByIdAsync(id.ToString());

            if (bookViewModel != null)
            {
                return View(bookViewModel);
            }

            return NotFound();
        }
        public async Task<IActionResult> PopularBooks() 
        {
            IEnumerable<AllBookViewModel> popularBooks = await 
                this.bookService.GetBooksByNumberOfSellsAsync();
            return View(popularBooks);
        }

        public async Task<IActionResult> AutorsBook(int id)
        {

            IEnumerable<AllBookViewModel> autorsBooks = await
                this.bookService.GetAllAutorsBookByIdAsync(id.ToString());

            return View(autorsBooks);
        }
    }
}
