
namespace GetThiqqq.Services
{
    public class UserExercise : Exercise
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Weight { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }
    }
}
