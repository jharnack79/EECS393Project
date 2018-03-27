using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Services
{
    public class Routine
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public int Frequency { get; set; }

        public List<UserExercise> Exercises { get; set; }

        public void AddExercise(UserExercise newExercise)
        {
            if(!Exercises.Contains(newExercise))
                Exercises.Add(newExercise);
        }

        public void RemoveExercise(UserExercise newExercise)
        {
            if (Exercises.Contains(newExercise))
                Exercises.Remove(newExercise);
        }

        public void UpdateFrequency(int newFrequency)
        {
            Frequency = newFrequency;
        }
    }
}
