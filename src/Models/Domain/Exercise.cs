using System.ComponentModel.DataAnnotations;

namespace src.Models.Domain
{
    public class Exercise
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int CountApproaches { get; set; }
        public int CountRepeats { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public Exercise(string name, int countApproaches, int countRepeats, int workoutId)
        {
            Name = name;
            CountApproaches = countApproaches;
            CountRepeats = countRepeats;
            WorkoutId = workoutId;
        }
    }
}
