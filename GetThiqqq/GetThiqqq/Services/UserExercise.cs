using System;
using System.Collections.Generic;
using System.Text;

namespace GetThiqqq.Services
{
    public class UserExercise : Exercise
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }
    }
}
