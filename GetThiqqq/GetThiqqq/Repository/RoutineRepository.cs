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

        List<Routine> GetAllRoutinesByUserId(int userId);
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
                                  "(RoutineId, ExerciseId, ExerciseWeight, NumOfReps, NumOfSets, UserId) " +
                                  "Values(" + newId + ", " + exerciseId + ", " +
                                  createRoutineViewModel.ExerciseWeight[i] + ", " +
                                  createRoutineViewModel.NumOfReps[i] + ", " + createRoutineViewModel.NumOfSets[i] + ", " +
                                  createRoutineViewModel.UserId + ")";

                cmd.ExecuteNonQuery();
                listOfExercises.Add(new UserExercise
                {
                    ExerciseName = createRoutineViewModel.Exercises[i],
                    Weight = createRoutineViewModel.ExerciseWeight[i],
                    Reps = createRoutineViewModel.NumOfReps[i],
                    Sets = createRoutineViewModel.NumOfSets[i],
                    UserId = createRoutineViewModel.UserId
                });
            }

            var routineCreated = new Routine
            {
                Exercises = listOfExercises,
                UserAccountId = createRoutineViewModel.UserId,
                Id = newId,
                Frequency = createRoutineViewModel.Frequency
            };

            sqlConnection.Close();
            return routineCreated;
    }

        public Routine GetRoutineById(int userId, int routineId)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from RoutineExercises Where UserId =" +
                              userId + " And RoutineId =" + routineId;
            cmd.Connection = sqlConnection;
            var reader = cmd.ExecuteReader();
            var listOfExercises = new List<UserExercise>();
            while (reader.Read())
            {
                listOfExercises.Add(new UserExercise
                {
                    ExerciseName = _exerciseRepository.GetExerciseById((int)reader["ExerciseId"]).ExerciseName,
                    Reps = (int)reader["NumOfReps"],
                    Sets = (int)reader["NumOfReps"],
                    Weight = (int)reader["ExerciseWeight"],
                    UserId = userId
                });
            }

            var routine = new Routine
            {
                Exercises = listOfExercises,
                Frequency = 3,
                UserAccountId = userId,
                Id = routineId
            };
            sqlConnection.Close();
            return routine; 
        }

        public List<Routine> GetAllRoutinesByUserId(int userId)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from RoutineExercises Where UserId = " +
                              userId + " Order By RoutineExercises.RoutineId";
            cmd.Connection = sqlConnection;
            var reader = cmd.ExecuteReader();
            var listOfExercises = new List<UserExercise>();
            var routines = new List<Routine>();
            var currentRoutineId = 0;
            var currentRoutine = new Routine();
            while (reader.Read())
            {
                if (currentRoutineId != (int) reader["RoutineId"])
                {
                    currentRoutine.Exercises = new List<UserExercise>(listOfExercises);
                    listOfExercises = new List<UserExercise>();
                    currentRoutineId = (int) reader["RoutineId"];
                    currentRoutine = new Routine
                    {
                        Id = currentRoutineId,
                        UserAccountId = userId
                    };
                    routines.Add(currentRoutine);
                }
                listOfExercises.Add(new UserExercise
                {
                    ExerciseName = _exerciseRepository.GetExerciseById((int)reader["ExerciseId"]).ExerciseName,
                    Reps = (int)reader["NumOfReps"],
                    Sets = (int)reader["NumOfReps"],
                    Weight = (int)reader["ExerciseWeight"],
                    UserId = userId
                });
            }

            sqlConnection.Close();
            currentRoutine.Exercises = new List<UserExercise>(listOfExercises);
            return routines;
        }
    }
}
