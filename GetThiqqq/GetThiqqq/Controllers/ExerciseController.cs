using Microsoft.AspNetCore.Mvc;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Controllers
{
    public class ExerciseController : Controller
    {
        public IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IActionResult ExerciseSearch()
        {
            return View();
        }

        public IActionResult ExerciseDemonstration(ExerciseSearchViewModel exerciseSearchViewModel)
        {
            var exercise = _exerciseRepository.GetExerciseByName(exerciseSearchViewModel.ExerciseName);

            var exerciseDemonstrationViewModel = new ExerciseDemonstratonViewModel
            {
                Exercise = exercise,
                UserAccountId = exerciseSearchViewModel.UserAccountId
            };

            return View(exerciseDemonstrationViewModel);
        }
    }
}
