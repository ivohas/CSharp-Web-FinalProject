﻿using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class BookService : IBookService
    {
        private readonly BooksDbContext dbContext;
        public BookService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBookViewModel>> AllBooksAsync()
        {
            var books = await this.dbContext
                .Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id.ToString(),
                    Title = b.Title,
                    Description = b.Description,
                    Pages = b.Pages,
                    ImageUrl = b.ImageUrl

                }).ToArrayAsync();

            return books;
        }

        public async Task<DetailsBookViewModel> GetBookByIdAsync(string bookId)
        {

            var book = await dbContext.Books
                .Include(b => b.Autor)
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id.ToString() == bookId);
            if (book != null)
            {
                return new DetailsBookViewModel
                {
                    Id = book.Id.ToString(),
                    Title = book.Title,
                    Description = book.Description,
                    Pages = book.Pages,
                    Price = book.Price,
                    ImageUrl = book.ImageUrl,
                    AutorName = $"{book.Autor.FirstName} {book.Autor.LastName}",
                    Category = book.Category.Name,
                    Publisher = book.Publisher.Name,
                    AutorId = book.AutorId
                };
            }

            return null;
        }
    }
}
