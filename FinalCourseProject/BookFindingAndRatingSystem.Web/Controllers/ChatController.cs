using Library.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class ChatController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
