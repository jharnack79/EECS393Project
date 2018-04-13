using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetThiqqq.Controllers
{
    public class RoutineController : Controller
    {
        
        [HttpGet]
        public IActionResult CreateRoutine()
        {
            TempData["Id"] = 0;
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoutine(CreateRoutineViewModel createRoutineViewModel)
        {

            return View();
        }

    }
}
