using System;
using System.Linq;
using System.Threading.Tasks;
using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Publisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class PublisherService : IPublisherService
    {
        private readonly ILogger<PublisherService> _logger;
        private readonly BooksDbContext _dbContext;

        public PublisherService(ILogger<PublisherService> logger, BooksDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        private async Task<Publisher> GetPublisherByNameAsync(string name)
        {
            return await _dbContext.Publishers.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while saving changes to the database.");
                throw; // Rethrow the exception
            }
        }

        public async Task CreateNewPublisher(AddPublisherViewModel model)
        {
            try
            {
                var existingPublisher = await GetPublisherByNameAsync(model.Name);

                if (existingPublisher != null)
                {
                    throw new Exception("A publisher with this name already exists.");
                }

                var newPublisher = new Publisher()
                {
                    Name = model.Name
                };

                _dbContext.Publishers.Add(newPublisher);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new publisher.");
                throw; // Rethrow the exception
            }
        }
    }
}
