using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GetThiqqq.Controllers
{
    public class RoutineController : Controller
    {
        private readonly IRoutineRepository _routineRepository;
        public RoutineController(IRoutineRepository routineRepository)
        {
            _routineRepository = routineRepository;
        }
        
        [HttpGet]
        public IActionResult CreateRoutine()
        {
            if (Request.Cookies["userAccountId"] == null)
                return RedirectToAction("CreateAccount", "Account");

            return View();
        }

        [HttpPost]
        public IActionResult CreateRoutine(CreateRoutineViewModel createRoutineViewModel)
        {
            createRoutineViewModel.UserId = int.Parse(Request.Cookies["userAccountId"]);
            _routineRepository.CreateRoutine(createRoutineViewModel);
            return View();
        }

        [HttpGet]
        public IActionResult ViewRoutine(int routineId)
        {
            var userId = int.Parse(Request.Cookies["userAccountId"]);
            var routine = _routineRepository.GetRoutineById(userId, routineId);
            return View();
        }

        [HttpGet]
        public IActionResult ViewAllRoutines()
        {
            var userId = int.Parse(Request.Cookies["userAccountId"]);
            var routineViewModel = new ViewAllRoutinesViewModel
            {
                UserId = userId,
                Routines = _routineRepository.GetAllRoutinesByUserId(userId)
            };
            return View(routineViewModel);
        }

    }
}
