using Microsoft.AspNetCore.Mvc;
using GetThiqqq.Models;
using GetThiqqq.Repository;


namespace GetThiqqq.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public IActionResult ExerciseSearch()
        {
            var exerciseSearchViewModel = new ExerciseSearchViewModel
            {
                UserId = 0
            };
            return View(exerciseSearchViewModel);
        }

        public IActionResult ExerciseDemonstration(ExerciseSearchViewModel exerciseSearchViewModel)
        {
            var exercise = _exerciseRepository.GetExerciseByName(exerciseSearchViewModel.ExerciseName);

            if (exercise == null)
            {
                return RedirectToAction("ExerciseSearch");
            }
            var exerciseDemonstrationViewModel = new ExerciseDemonstratonViewModel
            {
                Exercise = exercise,
                UserId = 0
            };

            return View(exerciseDemonstrationViewModel);
        }

        [HttpGet]
        public JsonResult GetAllExercises()
        {
            var exercises = _exerciseRepository.GetAllExercisesByName();
            return new JsonResult(exercises);
        }
    }
}
