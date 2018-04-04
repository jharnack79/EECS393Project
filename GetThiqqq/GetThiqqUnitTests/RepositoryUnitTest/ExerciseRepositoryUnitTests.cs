using NUnit.Framework;
using GetThiqqq.Repository;
using GetThiqqq.Services;

namespace GetThiqqUnitTests.RepositoryUnitTest
{
    [TestFixture]
    public class ExerciseRepositoryUnitTests
    {
        [Test]
        public void Should_get_all_exercises_by_name()
        {
            var exerciseRepository = new ExerciseRepository();
            var listOfExercises = exerciseRepository.GetAllExercisesByName();
            Assert.NotZero(listOfExercises.Count);
        }

        [Test]
        public void Should_get_exercise_by_name()
        {
            var exericse = new Exercise
            {
                ExerciseName = "Bench Press"
            };
            var exerciseRepository = new ExerciseRepository();
            var newExercise = exerciseRepository.GetExerciseByName("Bench Press");
            Assert.AreEqual(newExercise.ExerciseName, exericse.ExerciseName);
        }

        [Test]
        public void Should_not_get_exercise_if_doesnt_exist()
        {
            var exerciseRepository = new ExerciseRepository();
            var exercise = exerciseRepository.GetExerciseByName("Not an Exercise");
            Assert.IsNull(exercise);
        }
    }
}
