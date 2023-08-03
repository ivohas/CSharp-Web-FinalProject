using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Publisher;
using Library.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class PublisherController : BaseController
    {
        private readonly IPublisherService publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddPublisherViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddPublisherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Model", "Invalid data");
                return this.View(model);
            }
            try
            {
                await this.publisherService.CreateNewPublisher(model);
            }
            catch (Exception)
            {
                return BadRequest("Couldn't save the new publisher");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
