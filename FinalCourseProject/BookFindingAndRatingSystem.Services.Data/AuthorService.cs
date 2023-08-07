using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.ViewModels;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Autor;
using BookFindingAndRatingSystem.Web.ViewModels.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class AuthorService : IAuthorService
    {
        private readonly BooksDbContext dbContext;
        private readonly ILogger<AuthorService> logger;

        public AuthorService(BooksDbContext dbContext, ILogger<AuthorService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task CreateNewAuthorAsync(AuthorViewModel model)
        {
            try
            {
                var author = new Autor
                {
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                    BirthDate = model.BirthDate,
                    ImageUrl = model.ImageUrl
                };
                dbContext.Autors.AddRange(author);
                await dbContext.SaveChangesAsync();

                logger.LogInformation("New author created: {FirstName} {LastName}", author.FirstName, author.LastName);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating a new author");
                throw;
            }
        }

        public async Task EditAuthorAsync(AuthorViewModel model)
        {
            try
            {
                var author = await this.dbContext.Autors.Where(b => b.Id == model.Id).FirstOrDefaultAsync();

                if (author != null)
                {
                    author.FirstName = model.FirstName;
                    author.LastName = model.LastName;
                    author.BirthDate = model.BirthDate;
                    author.ImageUrl = model.ImageUrl;
                    await dbContext.SaveChangesAsync();

                    logger.LogInformation("Author edited: {FirstName} {LastName}", author.FirstName, author.LastName);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while editing the author");
                throw;
            }
        }

        public async Task<IEnumerable<AllAutorViewModel>> GetAllAutorsAsync()
        {
            try
            {
                var authors = await this.dbContext.Autors
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
                    })
                    .ToArrayAsync();

                logger.LogInformation("Retrieved {Count} authors", authors.Length);

                return authors;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting all authors");
                throw;
            }
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAutorsBookAsync(string id)
        {
            try
            {
                var books = await this.dbContext.Books
                    .Where(b => b.AutorId.ToString() == id)
                    .Select(b => new AllBookViewModel
                    {
                        Title = b.Title,
                        Pages = b.Pages,
                        Price = b.Price,
                    })
                    .ToArrayAsync();

                logger.LogInformation("Retrieved {Count} books for author with ID {AuthorId}", books.Length, id);

                return books;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting all books for author with ID {AuthorId}", id);
                throw;
            }
        }

        public async Task<AuthorViewModel> GetAuthorForEditByIdAsync(int id)
        {
            try
            {
                var model = await this.dbContext.Autors
                    .Where(a => a.Id == id)
                    .Select(a => new AuthorViewModel
                    {
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        ImageUrl = a.ImageUrl,
                        BirthDate = a.BirthDate
                    })
                    .AsQueryable()
                    .Take(1)
                    .FirstOrDefaultAsync();

                if (model != null)
                {
                    logger.LogInformation("Retrieved author for edit with ID {AuthorId}", id);
                    return model;
                }
                else
                {
                    logger.LogWarning("Author not found for edit with ID {AuthorId}", id);
                    throw new Exception("Author not found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting author for edit with ID {AuthorId}", id);
                throw;
            }
        }

        public async Task<AllAutorViewModel?> GetAutorByIdAsync(string id)
        {
            try
            {
                var author = await this.dbContext.Autors
                    .Select(a => new AllAutorViewModel
                    {
                        Id = a.Id,
                        FirstName = a.FirstName,
                        LastName = a.LastName,
                        ImageUrl = a.ImageUrl,
                        BirthDate = a.BirthDate
                    })
                    .FirstOrDefaultAsync(a => a.Id.ToString() == id);

                if (author != null)
                {
                    logger.LogInformation("Retrieved author with ID {AuthorId}", id);
                    return author;
                }
                else
                {
                    logger.LogWarning("Author not found with ID {AuthorId}", id);
                    return null;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while getting author with ID {AuthorId}", id);
                throw;
            }
        }
    }
}
