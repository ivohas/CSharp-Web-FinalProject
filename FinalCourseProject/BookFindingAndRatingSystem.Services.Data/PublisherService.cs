using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.Data;
using BookFindingAndRatingSystem.Web.ViewModels.Publisher;
using Microsoft.EntityFrameworkCore;

namespace BookFindingAndRatingSystem.Services.Data
{
    public class PublisherService : IPublisherService
    {

        private readonly BooksDbContext dbContext;

        public PublisherService(BooksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateNewPublisher(AddPublisherViewModel model)
        {
            bool alreadyExist = await this.dbContext.Publishers.Where(p => p.Name.ToLower() == model.Name.ToLower()).AnyAsync();
            if (alreadyExist)
            {
                throw new Exception("There is already publisher with this name");
            }
            var publisher = new Publisher()
            {
                Name = model.Name
            };

            this.dbContext.Publishers.AddRange(publisher);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
