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
    }
}
