﻿using Library.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BookFindingAndRatingSystem.Web.Controllers
{
    public class InfoController : BaseController
    {
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
