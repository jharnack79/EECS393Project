using System;
using System.Collections.Generic;
using System.Text;
using GetThiqqq.Services;

namespace GetThiqqq.Models
{
    public class CreateRoutineViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public int Frequency { get; set; }

        public List<string> Exercises { get; set; }

        public List<int> NumOfSets { get; set; }

        public List<int> NumOfReps { get; set; }

        public List<int> ExerciseWeight { get; set; }


    }
}
