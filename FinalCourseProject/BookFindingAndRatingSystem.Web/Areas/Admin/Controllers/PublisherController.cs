using BookFindingAndRatingSystem.Services.Data.Interfaces;
using BookFindingAndRatingSystem.Web.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BookFindingAndRatingSystem.Common.GeneralApplicationConstansts;

namespace BookFindingAndRatingSystem.Web.Areas.Admin.Controllers
{
    public class PublisherController : BaseAdminController
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet]
        [Authorize(Roles = AdminRoleName)]
        public IActionResult Add()
        {
            var model = new AddPublisherViewModel();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = AdminRoleName)]
        public async Task<IActionResult> Add(AddPublisherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid data!";
                ModelState.AddModelError("Model", "Invalid data");
                return View(model);
            }

            try
            {
                await this.publisherService.CreateNewPublisher(model);
                TempData["SuccessMessage"] = "New publisher added successfully!";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Couldn't save the new publisher due to an error!";
                return RedirectToAction(nameof(Add));
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
