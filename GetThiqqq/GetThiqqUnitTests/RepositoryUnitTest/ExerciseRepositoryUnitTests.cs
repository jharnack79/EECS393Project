using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            var listOfExercises = exerciseRepository.GetAllExercisesByName();
            Assert.NotZero(listOfExercises.Count);
        }

        [Test]
        public void Should_get_exercise_by_name()
        {
            Exercise exericse = new Exercise
            {
                ExerciseName = "Bench Press"
            };
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            var newExercise = exerciseRepository.GetExerciseByName("Bench Press");



        }

        [Test]
        public void Should_not_get_exercise_if_doesnt_exist()
        {
            ExerciseRepository exerciseRepository = new ExerciseRepository();
            var exercise = exerciseRepository.GetExerciseByName("Not an Exercise");
            Assert.IsNull(exercise);
        }
    }
}
