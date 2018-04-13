using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Services;
using System.Data.SqlClient;
using GetThiqqq.Constants;

namespace GetThiqqq.Repository
{
    public interface IExerciseRepository
    {
        Exercise GetExerciseByName(string exerciseName);

        List<string> GetAllExercisesByName();
    }

    public class ExerciseRepository : IExerciseRepository
    {
        public Exercise GetExerciseByName(string exerciseName)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from Exercise Where Name = '" + exerciseName
                + "'";
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();

            if (!reader.Read())
                return null;

            var exerciseInstructions = (string)reader["Instructions"];
            var exerciseDescription = (string)reader["Description"];

            var exercise = new Exercise
            {
                ExerciseName = exerciseName,
                Description = exerciseDescription,
                Instructions = exerciseInstructions
            };

            return exercise;
        }

        public List<string> GetAllExercisesByName()
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Name from Exercise";
            cmd.Connection = sqlConnection;

            var reader = cmd.ExecuteReader();
            var listOfExercises = new List<string>();
            while (reader.Read())
            {
                listOfExercises.Add((string)reader["Name"]);
            }
            return listOfExercises;
        }
    }
}
