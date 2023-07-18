using BookFindingAndRatingSystem.Web.ViewModels.Home;
using Library.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        

        public HomeController()
        {            
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}