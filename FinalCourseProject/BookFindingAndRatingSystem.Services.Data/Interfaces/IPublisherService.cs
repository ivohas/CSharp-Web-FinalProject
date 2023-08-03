using BookFindingAndRatingSystem.Web.ViewModels.Publisher;

namespace BookFindingAndRatingSystem.Services.Data.Interfaces
{
    public interface IPublisherService
    {
        Task CreateNewPublisher(AddPublisherViewModel model);
    }
}
