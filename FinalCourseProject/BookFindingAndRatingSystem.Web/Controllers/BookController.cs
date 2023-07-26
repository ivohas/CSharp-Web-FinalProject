using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Services.Data.Models.Book;
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
        private readonly ICategoryService categoryService;
        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
        }
        [HttpGet]
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

        public async Task<IActionResult> WantToRead(string id)
        {
            var book = await this.bookService.GetBookByIdAsync(id.ToString());

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = this.GetUserId();
            // try catch
            await this.bookService.AddBookToUserByIdAsync(userId, book);

            return RedirectToAction(nameof(Mine));
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = this.GetUserId();

            IEnumerable<AllBookViewModel> myBooks = await this.bookService.GetAllBookByUserId(userId);
            return View(myBooks);
        }
        public async Task<IActionResult> RemoveFromMine(string id)
        {
            var myBook = await this.bookService.GetBookByIdAsync(id.ToString());

            if (myBook == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = this.GetUserId();

            await bookService.RemoveBookFromMyBooksAsync(userId, myBook);
            return RedirectToAction(nameof(Mine));
        }

        public async Task<IActionResult> Search([FromQuery]AllBookQueryModel queryModel)
        {
            AllBookFilteredAndPagedSerivceModel serviceModel = await this.bookService.AllAsync(queryModel);

            queryModel.Books = serviceModel.Books;
            queryModel.BooksCount = serviceModel.TotalBooksCount;
            queryModel.Categories = await this.categoryService.AllCategoriesNameAsync();

            return View(queryModel);
        }
        
        public Task<IActionResult> Edit(string id)
        {
            throw new NotImplementedException();
        }
    }
}
