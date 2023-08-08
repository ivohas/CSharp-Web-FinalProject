﻿using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Services.Data.Models.Book;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Library.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.NotificationMessagesConstants;
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
                TempData[ErrorMessage] = "The books could not be loaded. Please try again later.";
                return RedirectToAction(nameof(Index), "Home");
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
                TempData[ErrorMessage] = "There is no book with this ID. Please try again later.";
                return RedirectToAction(nameof(All));
            }

            if (book != null)
            {
                return View(book);
            }

            TempData[ErrorMessage] = "Book details could not be loaded.";
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
                TempData[ErrorMessage] = "Problem occurred while fetching popular books. Please try again later.";
                return RedirectToAction(nameof(All));
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
                TempData[ErrorMessage] = "An error occurred while fetching author's books.";
                return RedirectToAction(nameof(All));
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
                TempData[ErrorMessage] = "An error occurred while marking the book as 'Want to Read'.";
                return RedirectToAction(nameof(Details), new { id });
            }

            if (book == null)
            {
                TempData[ErrorMessage] = "Book not found.";
                return RedirectToAction(nameof(Details), new { id });
            }

            var userId = this.GetUserId();
            try
            {
                await this.bookService.AddBookToUserByIdAsync(userId, book);
                TempData[SuccessMessage] = "Book added to your collection.";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An error occurred while adding the book to your collection.";
            }

            return RedirectToAction(nameof(Details), new { id });
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
                TempData[ErrorMessage] = "An error occurred while fetching your books.";
                return RedirectToAction(nameof(Index), "Home");
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
                TempData[ErrorMessage] = "An error occurred while removing the book from your collection.";
                return RedirectToAction(nameof(Mine));
            }

            if (myBook == null)
            {
                TempData[ErrorMessage] = "Book not found in your collection.";
                return RedirectToAction(nameof(Mine));
            }

            var userId = this.GetUserId();
            try
            {
                await bookService.RemoveBookFromMyBooksAsync(userId, myBook);
                TempData[SuccessMessage] = "Book removed from your collection.";
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An error occurred while removing the book from your collection.";
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
                TempData[ErrorMessage] = "An error occurred while searching for books.";
                return RedirectToAction(nameof(All));
            }

            queryModel.Books = serviceModel.Books;
            queryModel.BooksCount = serviceModel.TotalBooksCount;
            try
            {
                queryModel.Categories = await this.categoryService.AllCategoriesNameAsync();
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "An error occurred while fetching categories.";
                return RedirectToAction(nameof(All));
            }

            return View(queryModel);
        }

        public IActionResult Rate(string id)
        {
            TempData[ErrorMessage] = "Rating functionality not implemented yet.";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
