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
        public IActionResult Error(int statusCode)
        {
            if (statusCode==400||statusCode==404)
            {
                return this.View("Error404");
            }
            if (statusCode==401)
            {
                return this.View("Error401");
            }
            return this.View();
        }
    }
}