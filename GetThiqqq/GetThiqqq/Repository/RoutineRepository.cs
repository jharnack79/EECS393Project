using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using GetThiqqq.Constants;
using GetThiqqq.Models;
using GetThiqqq.Services;
using System.Linq;

namespace GetThiqqq.Repository
{
    public interface IRoutineRepository
    {
        Routine CreateRoutine(CreateRoutineViewModel createRoutineViewModel);

        Routine GetRoutineById(int userId, int routineId);
    }
    public class RoutineRepository : IRoutineRepository
    {
        private readonly IExerciseRepository _exerciseRepository;

        public RoutineRepository(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public Routine CreateRoutine(CreateRoutineViewModel createRoutineViewModel)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Max(RoutineId) from RoutineExercises";
            cmd.Connection = sqlConnection;

            var newId = (int) cmd.ExecuteScalar() + 1;
            var listOfExercises = new List<UserExercise>();
            for (var i = 0; i < createRoutineViewModel.Exercises.Count; i++ )
            {
                var exerciseId = _exerciseRepository.GetExerciseIdByName(createRoutineViewModel.Exercises[i]);

                cmd.CommandText = "Insert Into [GetThiqq].[dbo].[RoutineExercises]" +
                                  "(RoutineId, ExerciseId, ExerciseWeight, NumOfReps, NumOfSets) " +
                                  "Values(" + newId + ", " + exerciseId + ", " +
                                  createRoutineViewModel.ExerciseWeight[i] + ", " +
                                  createRoutineViewModel.NumOfReps[i] + ", " + createRoutineViewModel.NumOfSets[i] +
                                  ")";

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    listOfExercises.Add(new UserExercise
                    {
                        ExerciseName = createRoutineViewModel.Exercises[i],
                        Weight = createRoutineViewModel.ExerciseWeight[i],
                        Reps = createRoutineViewModel.NumOfReps[i],
                        Sets = createRoutineViewModel.NumOfSets[i],
                        UserId = createRoutineViewModel.UserId
                    });
                }

            }

            var routineCreated = new Routine
            {
                Exercises = listOfExercises,
                UserAccountId = createRoutineViewModel.UserId,
                Id = newId
            };
            return routineCreated;
    }

        public Routine GetRoutineById(int userId, int routineId)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Max(RoutineId) from RoutineExercises";
            cmd.Connection = sqlConnection;

            return null;
        }
    }
}
