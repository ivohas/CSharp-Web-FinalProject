using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Services.Data.Models.Book;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Library.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
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
            IEnumerable<AllBookViewModel> allBooks;
            try
            {
                allBooks = await this.bookService.AllBooksAsync();
            }
            catch (Exception)
            {
                return this.BadRequest("The books can not be loaded, please try again later!");
            }

            return View(allBooks);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            DetailsBookViewModel book;
            try
            {
                var userId = GetUserId();
                book = await bookService.GetBookByIdAsync(id.ToString(), userId!);
            }
            catch (Exception)
            {
                return this.BadRequest("There is no book with this id, please try again later!");
            }

            if (book != null)
            {

                return View(book);
            }

            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> PopularBooks()
        {
            IEnumerable<AllBookViewModel> popularBooks;
            try
            {
                popularBooks = await this.bookService.GetBooksByNumberOfSellsAsync();
            }
            catch (Exception)
            {
                return this.BadRequest("Problem ocured, try again later!");
            }

            return View(popularBooks);
        }
        [HttpGet]
        public async Task<IActionResult> AutorsBook(int id)
        {
            IEnumerable<AllBookViewModel> authorsBooks;

            try
            {
                authorsBooks = await this.bookService.GetAllAutorsBookByIdAsync(id.ToString());
            }
            catch (Exception)
            {
                return this.BadRequest("Error ocurred!");
            }
            return View(authorsBooks);
        }

        public async Task<IActionResult> WantToRead(string id)
        {
            DetailsBookViewModel book;
            try
            {
                book = await this.bookService.GetBookByIdAsync(id.ToString(), this.GetUserId()!);
            }
            catch (Exception)
            {
                return this.BadRequest("No book by id");
            }


            if (book == null)
            {
                return NotFound();
            }

            var userId = this.GetUserId();
            try
            {
                await this.bookService.AddBookToUserByIdAsync(userId, book);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Mine));
        }
        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = this.GetUserId();
            IEnumerable<AllBookViewModel> myBooks;
            try
            {
                myBooks = await this.bookService.GetAllBookByUserId(userId);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            return View(myBooks);
        }
        public async Task<IActionResult> RemoveFromMine(string id)
        {
            DetailsBookViewModel myBook;
            try
            {
                myBook = await this.bookService.GetBookByIdAsync(id.ToString(), this.GetUserId()!);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            if (myBook == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = this.GetUserId();
            try
            {
                await bookService.RemoveBookFromMyBooksAsync(userId, myBook);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            return RedirectToAction(nameof(Mine));
        }
        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] AllBookQueryModel queryModel)
        {
            AllBookFilteredAndPagedSerivceModel serviceModel;
            try
            {
                serviceModel = await this.bookService.AllAsync(queryModel);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }


            queryModel.Books = serviceModel.Books;
            queryModel.BooksCount = serviceModel.TotalBooksCount;
            try
            {
                queryModel.Categories = await this.categoryService.AllCategoriesNameAsync();
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            return View(queryModel);
        }
        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(string id)
        {
            EditBookViewModel book;
            try
            {
                book = await this.bookService.GetBookForEditByIdAsync(id);
            }
            catch (Exception)
            {
                return this.BadRequest();
            }

            if (book == null)
            {
                return RedirectToAction($"Details({Guid.Parse(id)})");
            }
            return View(book);
        }
        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Edit(EditBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data!");
            }
            try
            {
                await this.bookService.EditBookAsync(book);
            }
            catch (Exception)
            {
                return this.BadRequest("The book can't be edited");
            }

            return RedirectToAction("Details", new { id = $"{book.Id}" });
        }
        public IActionResult Rate(string id)
        {
            throw new NotImplementedException();
        }      
    }
}
