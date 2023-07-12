using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class AutorService : IAutorService
    {
        private readonly BooksDbContext dbContext;
        public AutorService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllAutorViewModel>> GetAllAutorsAsync()
        {
            return await this.dbContext
                 .Autors
                 .Select(a => new AllAutorViewModel
                 {
                     Id = a.Id,
                     FirstName = a.FirstName,
                     LastName = a.LastName,
                     ImageUrl = a.ImageUrl,
                     Books = a.Books.Select(b => new AllBookViewModel
                     {
                         Id = b.Id.ToString(),
                         ImageUrl = b.ImageUrl,
                         Title = b.Title,
                         Description = b.Description,
                         Pages = b.Pages,
                         Price = b.Price

                     }).ToList()
                 }).ToArrayAsync();
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookAsync(string id)
        {
            return await this.dbContext
                .Books
                .Where(b=> b.AutorId.ToString() == id)
                .Select(b => new AllBookViewModel
                {
                    Title = b.Title,
                    Pages = b.Pages,
                    Price = b.Price,
                }).ToArrayAsync();

                
        }

        public async Task<AllAutorViewModel?> GetAutorByIdAsync(string id)
        {
            return await this.dbContext
                .Autors
                .Select(a => new AllAutorViewModel
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    ImageUrl = a.ImageUrl,
                    BirthDate = a.BirthDate.ToString()
                })
                .FirstOrDefaultAsync(a => a.Id.ToString() == id);
                 
        }
    }
}
