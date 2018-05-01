using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Models;
using GetThiqqq.Repository;
using NUnit.Framework;

namespace GetThiqqUnitTests.RepositoryUnitTest
{
    [TestFixture]
    public class RoutineRepositoryUnitTests
    {
        private static readonly ExerciseRepository _exerciseRepository = new ExerciseRepository();
        private readonly RoutineRepository _routineRepository = new RoutineRepository(_exerciseRepository);

        [Test]
        public void Should_create_routine()
        {
            var createRoutineViewModel = new CreateRoutineViewModel
            {
                UserId = 0,
                Frequency = 3,
                Exercises = new List<string> {"Bench Press"},
                ExerciseWeight = new List<int> {125},
                NumOfReps = new List<int> {5},
                NumOfSets = new List<int> {5},

            };
            var routine = _routineRepository.CreateRoutine(createRoutineViewModel);
            Assert.NotNull(routine);
        }

        [Test]
        public void Should_get_routine_when_exists()
        {
            Assert.NotNull(_routineRepository.GetRoutineById(1, 1));
        }

        [Test]
        public void Should_not_get_routine_when_none_exists()
        {
            Assert.IsEmpty(_routineRepository.GetRoutineById(1000, 1000).Exercises);
        }

        [Test]
        public void Should_get_all_user_routines()
        {
            Assert.NotNull(_routineRepository.GetAllRoutinesByUserId(1));
        }
    }
}
