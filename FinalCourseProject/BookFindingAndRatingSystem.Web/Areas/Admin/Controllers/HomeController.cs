using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
