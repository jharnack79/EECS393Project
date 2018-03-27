using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace GetThiqqq.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult CreatePost()
        {
            return View();
        }
    }
}
