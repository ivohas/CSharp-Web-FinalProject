using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly BooksDbContext _dbContext;

        public CategoryService(ILogger<CategoryService> logger, BooksDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllCategoriesNameAsync()
        {
            try
            {
                var categoryNames = await _dbContext.Categories
                    .Select(c => c.Name)
                    .ToArrayAsync();

                return categoryNames;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all category names.");
                throw; // Rethrow the exception
            }
        }
    }
}
