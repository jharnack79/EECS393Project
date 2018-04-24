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

        int GetExerciseIdByName(string exerciseName);

        Exercise GetExerciseById(int id);
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
            var exerciseVideoLink = GetExerciseVideo(exerciseName);
            var exercise = new Exercise
            {
                ExerciseName = exerciseName,
                Description = exerciseDescription,
                Instructions = exerciseInstructions,
                VideoLink = exerciseVideoLink
            };
            sqlConnection.Close();
            return exercise;
        }

        private string GetExerciseVideo(string exerciseName)
        {
            var value = exerciseName;
            var link = "";

            switch(value)
            {
                case "Bench Press":
                    link = ExerciseConstants.BenchPress;
                    break;
                case "Squat":
                    link = ExerciseConstants.Squat;
                    break;
                case "Deadlift":
                    link = ExerciseConstants.Deadlift;
                    break;
                case "Front Squat":
                    link = ExerciseConstants.FrontSquat;
                    break;
                case "Lunges":
                    link = ExerciseConstants.Lunges;
                    break;
                case "Dumbbell Press":
                    link = ExerciseConstants.DumbbellPress;
                    break;
                case "Hyperextensions":
                    link = ExerciseConstants.Hyperextensions;
                    break;
                case "Calf Raises":
                    link = ExerciseConstants.CalfRaises;
                    break;
                case "Hamstring Curls":
                    link = ExerciseConstants.HamstringCurls;
                    break;
                case "Chest Flyes":
                    link = ExerciseConstants.ChestFlyes;
                    break;
                default:
                    link = "";
                    break;
            }
            return link;

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
            sqlConnection.Close();
            return listOfExercises;
        }

        public int GetExerciseIdByName(string exerciseName)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select Id from Exercise Where Name = '" +
                              exerciseName + "'";
            cmd.Connection = sqlConnection;
            var reader = cmd.ExecuteReader();

            if(!reader.Read())
                return 0;

            return (int)reader["Id"];
        }

        public Exercise GetExerciseById(int id)
        {
            var sqlConnection = new SqlConnection(DatabaseConstants.ConnectionString);
            var cmd = new SqlCommand();

            sqlConnection.Open();
            cmd.CommandText = "Select * from Exercise Where Id = '" +
                              id + "'";
            cmd.Connection = sqlConnection;
            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Exercise
                {
                    ExerciseName = (string) reader["name"],
                    Description = (string) reader["Description"],
                    VideoLink = GetExerciseVideo((string) reader["name"]),
                    Instructions = (string) reader["Instructions"]
                };
            }
            sqlConnection.Close();
            return null;
        }
    }
}
