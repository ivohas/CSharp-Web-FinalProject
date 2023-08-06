using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;
namespace BookFindingAndRatingSystem.Web.Areas.Admin.Controllers
{
    public class BookController : BaseAdminController
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            var model = new AddBookViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model", "Invalid data");
                return this.View(model);
            }
            try
            {
                await this.bookService.CreateNewBookAsync(model);
            }
            catch (Exception)
            {
                return BadRequest("Couldn't save the new book");
            }


            return RedirectToAction("All", "Book", new { area = "" });
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

            return RedirectToAction("Details", new { id = $"{book.Id}", area = "" });
        }
    }
}
