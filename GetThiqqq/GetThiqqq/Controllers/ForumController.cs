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

        public IActionResult CreateTopic()
        {
            return View();
        }

        public IActionResult ForumHome()
        {
            return View();
        }

        public IActionResult ForumTopic()
        {
            return View();
        }
    }
}
